using Leopotam.Ecs;
using UnityEngine;

namespace MarsRunner
{
    public class CleanObstaclesSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Obstacle, Position, ObstacleViewRef> _obstacles;
        private readonly EcsFilter<Player, Position> _player;
        private readonly EcsWorld _world;
        
        public void Run()
        {
            if (_player.IsEmpty()) return;

            var playerPosition = _player.Get2(0).value;

            foreach (var index in _obstacles)
            {
                if (_obstacles.Get2(index).value.z < playerPosition.z)
                {
                    Object.Destroy(_obstacles.Get3(index).value.gameObject);
                    _obstacles.GetEntity(index).Destroy();
                }
            }
        }
    }
}