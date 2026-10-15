using System.Collections;
using UnityEngine.UIElements;

namespace Selectica
{
    [ExecuteAuto]
    public interface IExecuteOnGameScreenSpaceUIReady
    {
        IEnumerator Execute(params object[] args)
        {
            var validator = new ArgsValidator(GetType(), args);
            var uiRoot = validator.ValidateAt<VisualElement>(0);
            
            yield return ExecuteOnGameScreenSpaceUIReady(uiRoot);
        }

        IEnumerator ExecuteOnGameScreenSpaceUIReady(VisualElement uiRoot);
    }
}