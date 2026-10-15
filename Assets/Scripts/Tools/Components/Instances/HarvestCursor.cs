using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Selectica
{
    public class HarvestCursor : MonoBehaviour
    {
        public MeshRenderer meshRenderer;
        public Material cursorMaterial;
        public float offsetSpeed;

        private bool _harvesting;
        
        private static readonly int Offset = Shader.PropertyToID("_Offset");
        private float _offset;

        private int _mask;
        private readonly Collider[] _buffer = new Collider[16];
        private readonly HashSet<Entity> _harvestableCache = new();
        
        public void Activate()
        {
            var camera = Camera.main;
            var mouse = Mouse.current;
            var surface = new Plane(Vector3.up, Vector3.zero);
            
            _mask = LayerMask.GetMask("Harvestable");
            meshRenderer.enabled = false;
            
            if (camera == null || mouse == null) return;
            if (_harvesting)
            {
                Debug.LogWarning("Already activated");
                return;
            }

            _harvesting = true;
            Coroutines.Start(HarvestCursorRoutine(camera, mouse, surface), this);
        }

        private IEnumerator HarvestCursorRoutine(Camera camera, Mouse mouse, Plane surface)
        {
            while (_harvesting)
            {
                var mousePos = mouse.position.ReadValue();
                var ray = camera.ScreenPointToRay(mousePos);

                yield return SetPositionRoutine(surface, ray);
                yield return AnimationRoutine();
                yield return HarvestRoutine();
                
                yield return null;
            }
        }

        private IEnumerator SetPositionRoutine(Plane surface, Ray ray)
        {
            if (!surface.Raycast(ray, out var enter)) yield break;
            
            var worldPos = ray.GetPoint(enter);
            var position = new Vector3(worldPos.x, 0, worldPos.z);
            transform.position = position;

            if (meshRenderer.enabled) yield break;
            
            yield return null;
            yield return null;
            meshRenderer.enabled = true;
        }

        private IEnumerator AnimationRoutine()
        {
            _offset = Mathf.Clamp01(_offset + Time.deltaTime * offsetSpeed);
            if (_offset >= 1) _offset = Time.deltaTime * offsetSpeed;
            
            cursorMaterial.SetFloat(Offset, _offset);
            yield return null;
        }

        private IEnumerator HarvestRoutine()
        {
            var scale = transform.lossyScale;
            var radius = Mathf.Min(Mathf.Abs(scale.x), Mathf.Abs(scale.y)) * 0.5f;

            var endHarvestEntities = new List<Entity>(_harvestableCache);
            var count = Physics.OverlapSphereNonAlloc(transform.position, radius, _buffer, _mask);
            for (var i = 0; i < count; i++)
            {
                var collider = _buffer[i];
                if (!collider.TryGetComponent<HarvestCollider>(out var harvestable)) continue;
                var entity = harvestable.entity;

                endHarvestEntities.Remove(entity);
                if (_harvestableCache.Add(entity))
                {
                    yield return ExecutorsRegistry.ExecuteAll<IExecuteOnEntityBeginHarvest>(entity);
                }
            }

            foreach (var entity in endHarvestEntities)
            {
                _harvestableCache.Remove(entity);
                yield return ExecutorsRegistry.ExecuteAll<IExecuteOnEntityEndHarvest>(entity);
            }
            
            yield return null;
        }

        public IEnumerator StopHarvest()
        {
            if (!_harvesting)
            {
                Debug.LogWarning("Harvest was not activated");
            }
            _harvesting = false;
            yield return null;
            
            foreach (var entity in _harvestableCache)
            {
                yield return ExecutorsRegistry.ExecuteAll<IExecuteOnEntityEndHarvest>(entity);
            }
            
            yield return null;
        }
    }
}