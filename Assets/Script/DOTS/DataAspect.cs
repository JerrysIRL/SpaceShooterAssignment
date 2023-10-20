using Unity.Entities;
using Unity.Transforms;

namespace Script.DOTS
{
    public readonly partial struct DataAspect : IAspect
    {
        public readonly Entity Entity;
        
        private readonly RefRO<LocalTransform> _transform;
        private readonly RefRO<DataProperties> _dataProperties;
        private readonly RefRW<DataRandom> _dataRandom;
    }
}