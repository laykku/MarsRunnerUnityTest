using Leopotam.Ecs;

namespace MarsRunner
{
    public class ResetOriginSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Player, Position> _filter;
        private readonly Configuration _configuration;
        
        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var position = ref _filter.Get2(index).value;

                if (position.z >= _configuration.ResetOriginDistance)
                {
                    position.z = 0f;
                }
            }
        }
    }
}