using System.Collections;

namespace Selectica
{
    [ExecuteAuto]
    public interface IExecuteOnSelectInputPerformed
    {
        IEnumerator Execute(params object[] args) => ExecuteOnSelectInputPerformed();

        IEnumerator ExecuteOnSelectInputPerformed();
    }
}