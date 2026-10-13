using System.Collections;

namespace Selectica
{
    [ExecutePriority(0)]
    public class GameLoadHandler : IOnGameLoadHandler
    {
        public IEnumerator ExecuteOnGameLoad()
        {
            yield return Scenes.LoadScene("Game");
            yield return null;
        }
    }
}