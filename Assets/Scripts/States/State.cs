using System.Collections;

namespace Selectica
{
    public abstract class State
    {
        public virtual IEnumerator EnterState() { yield return null; }
        public abstract IEnumerator HandleInput(Input input);
        public virtual IEnumerator ExitState() { yield return null; }
    }
}