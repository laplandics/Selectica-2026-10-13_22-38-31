using System.Collections;
using UnityEngine;

namespace Selectica
{
    [ExecutePriority(0)]
    public class MenuLoadHandler : IOnMenuLoadHandler
    {
        public IEnumerator ExecuteOnMenuLoad()
        {
            yield return Scenes.LoadScene("Menu");
            yield return new WaitForSeconds(0.5f);
            yield return Handlers.ExecuteHandlers<IOnGameLoadHandler>();
        }
    }
}