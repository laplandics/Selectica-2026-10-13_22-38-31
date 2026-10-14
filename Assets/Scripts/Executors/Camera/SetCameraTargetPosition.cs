using System.Collections;
using UnityEngine;

namespace Selectica
{
    public class SetCameraTargetPosition : IExecuteOnCameraReady
    {
        public IEnumerator ExecuteOnCameraReady(GameObject cameraObject)
        {
            var target = cameraObject.transform.Find("Target");
            if (target == null)
            {
                Debug.LogError("Camera Target not found");
                yield break;
            }

            var position = Grid.Snap(Vector3.zero);
            target.localPosition = position;
            yield return null;
        }
    }
}