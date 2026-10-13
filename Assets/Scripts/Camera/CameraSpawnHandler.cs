using System.Collections;
using UnityEngine;

namespace Selectica
{
    [ExecutePriority(1)]
    public class CameraSpawnHandler : IOnGameLoadHandler
    {
        public IEnumerator ExecuteOnGameLoad()
        {
            var gameCameraPrefab = R.AssetsLoader<GameObject>.GetAsset("GameCamera");
            var gameCameraObject = Object.Instantiate(gameCameraPrefab);
            gameCameraObject.name = "GameCamera";
            var gameCamera = gameCameraObject.GetComponent<CameraController>();
            gameCamera.Activate();
            
            var camera = gameCameraObject.GetComponentInChildren<Camera>();
            yield return null;
        }
    }
}