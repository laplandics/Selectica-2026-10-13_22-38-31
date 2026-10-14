using System.Collections;
using UnityEngine.SceneManagement;

namespace Selectica
{
    public class LoadMenuSceneOnBoot : IExecuteOnBoot
    {
        public IEnumerator ExecuteOnBoot()
        {
            yield return SceneManager.LoadSceneAsync("Menu");
            yield return ExecutorsRegistry.ExecuteAll<IExecuteOnMenuSceneLoad>();
        }
    }
}