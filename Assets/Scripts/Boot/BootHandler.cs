using System.Collections;

namespace Selectica
{
    public class BootHandler : IOnBootHandler
    {
        public IEnumerator ExecuteOnBoot()
        {
            yield return Scenes.LoadScene("Boot");
            yield return Handlers.ExecuteHandlers<IOnMenuLoadHandler>();
        }
    }
}