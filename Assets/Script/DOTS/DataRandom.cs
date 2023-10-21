using Unity.Entities;
using Unity.Mathematics;

namespace Script.DOTS
{
    public struct DataRandom : IComponentData
    {
        public Random Value;
    }
}