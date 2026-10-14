using System;

namespace Selectica
{
    [Serializable]
    public struct CellIndex : IEquatable<CellIndex>
    {
        public int x;
        public int z;
        public bool valid;

        public CellIndex(int x, int z)
        {
            this.x = x;
            this.z = z;
            valid = true;
        }
        
        public bool Equals(CellIndex other) => x == other.x && z == other.z && valid == other.valid;
        public override bool Equals(object obj) => obj is CellIndex other && Equals(other);
        public override int GetHashCode() => HashCode.Combine(x, z, valid);
        
        public static bool operator ==(CellIndex left, CellIndex right) => left.Equals(right);
        public static bool operator !=(CellIndex left, CellIndex right) => !left.Equals(right);
    }
}