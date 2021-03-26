using Leopotam.Ecs;
using UnityEngine;

namespace MarsRunner
{
    public class ObstacleGenerationSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Player, Position> _filter;
        private readonly Configuration _configuration;
        private readonly GameState _gameState;
        private readonly EcsWorld _world;

        public void Run()
        {
            if (Time.time - _gameState.LastObstacleAppearTime > _gameState.NextObstacleGeneration)
            {
                if (!_filter.IsEmpty())
                {
                    if (Random.Range(0f, 1f) < _configuration.ObstacleAppearChance)
                    {
                        var obstacleView = Object.Instantiate(_configuration.ObstacleViewPrefab);
                        
                        var obstaclePosition = new Vector3(0f, 0f,
                            _filter.Get2(0).value.z + Random.Range(
                                _configuration.ObstacleGenRangeBounds.x,
                                _configuration.ObstacleGenRangeBounds.y));
                        
                        obstacleView.transform.position = obstaclePosition;
                        
                        _gameState.NextObstacleGeneration = Random.Range(
                            _configuration.ObstacleGenTimeRange.x,
                            _configuration.ObstacleGenTimeRange.y);

                        _gameState.LastObstacleAppearTime = Time.time;

                        var obstacleEntity = _world.NewEntity();
                        obstacleEntity.Get<Obstacle>();
                        obstacleEntity.Get<ObstacleViewRef>().value = obstacleView;
                        obstacleEntity.Get<Position>().value = obstaclePosition;
                    }
                }
            }
        }
    }
}