using System.Collections;
using UnityEngine;

namespace Selectica
{
    [ExecutePriority(10)]
    public class SpawnCamera : IExecuteOnGameSceneLoad
    {
        public IEnumerator ExecuteOnGameSceneLoad()
        {
            var cameraPrefab = R.AssetsLoader<GameObject>.GetAsset("GameCamera");
            var cameraObject = Object.Instantiate(cameraPrefab);
            cameraObject.name = "GameCamera";
            
            var camera = cameraObject.GetComponentInChildren<Camera>();
            G.MainCamera = camera;
            
            yield return ExecutorsRegistry.ExecuteAll<IExecuteOnCameraReady>(cameraObject);
        }
    }
}