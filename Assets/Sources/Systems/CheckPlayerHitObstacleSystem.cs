using Leopotam.Ecs;

namespace MarsRunner
{
    public class CheckPlayerHitObstacleSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ObstacleViewRef> _obstacles;
        
        public void Run()
        {
            foreach (var index in _obstacles)
            {
                if (_obstacles.Get1(index).value.HasHit)
                {
                    _obstacles.GetEntity(index).Get<EndGameEvent>();
                    break;
                }
            }    
        }
    }
}