using System.Collections;
using UnityEngine.SceneManagement;

namespace Selectica
{
    public class LoadGameScene : IExecuteOnMenuSceneLoad
    {
        public IEnumerator ExecuteOnMenuSceneLoad()
        {
            yield return SceneManager.LoadSceneAsync("Game");
            yield return ExecutorsRegistry.ExecuteAll<IExecuteOnGameSceneLoad>();
        }
    }
}