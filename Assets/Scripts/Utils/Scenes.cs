using System.Collections;
using UnityEngine.SceneManagement;

namespace Selectica
{
    public static class Scenes
    {
        public static IEnumerator LoadScene(string sceneName)
        {
            yield return SceneManager.LoadSceneAsync(sceneName);
        }
    }
}
