using System.Collections;

namespace Selectica
{
    public interface IHandler
    {
        public IEnumerator Execute(params object[] args);
    }

    public interface IOnBootHandler : IHandler
    {
        IEnumerator IHandler.Execute(params object[] args) => ExecuteOnBoot();

        public IEnumerator ExecuteOnBoot();
    }
    
    public interface IOnEntitySpawnHandler : IHandler
    {
        IEnumerator IHandler.Execute(params object[] args)
        {
            if (args[0] is not Entity spawnEntity)
            { 
                throw new HandlerArgumentException(this, typeof(Entity), args[0]);
            }
            
            yield return ExecuteOnEntitySpawn(spawnEntity);
        }

        public IEnumerator ExecuteOnEntitySpawn(Entity entity);
    }
    
    public interface IOnMenuLoadHandler : IHandler
    {
        IEnumerator IHandler.Execute(params object[] args) => ExecuteOnMenuLoad();

        public IEnumerator ExecuteOnMenuLoad();
    }
    
    public interface IOnGameLoadHandler : IHandler
    {
        IEnumerator IHandler.Execute(params object[] args) => ExecuteOnGameLoad();
        
        public IEnumerator ExecuteOnGameLoad();
    }
}