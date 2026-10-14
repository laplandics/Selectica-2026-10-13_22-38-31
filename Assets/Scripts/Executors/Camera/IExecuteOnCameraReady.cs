using System.Collections;
using UnityEngine;

namespace Selectica
{
    [ExecuteAuto]
    public interface IExecuteOnCameraReady
    {
        IEnumerator Execute(params object[] args)
        {
            var validator = new ArgsValidator(GetType(), args);
            var cameraObject = validator.ValidateAt<GameObject>(0);
            
            yield return ExecuteOnCameraReady(cameraObject);
        }

        IEnumerator ExecuteOnCameraReady(GameObject cameraObject);
    }
}