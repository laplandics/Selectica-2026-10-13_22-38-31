using System.Collections.Generic;
using UnityEngine;

namespace Selectica
{
    public static class G
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void Reset()
        {
            MainCamera = null;
            SelectedEntity = null;
            
            CellsMap.Clear();
            EntitiesMap.Clear();
        }

        public static Camera MainCamera;
        public static Entity SelectedEntity;
        
        public static readonly Dictionary<CellIndex, Cell> CellsMap = new();
        public static readonly Dictionary<string, Entity> EntitiesMap = new();
    }
}