using Leopotam.Ecs;
using UnityEngine;

namespace MarsRunner
{
    public class SpawnPlayerSystem : IEcsInitSystem
    {
        private readonly Configuration _configuration;
        private readonly EcsWorld _world;
        
        public void Init()
        {
            var playerEntity = _world.NewEntity();
            playerEntity.Get<Player>();
            playerEntity.Get<Position>().value = Vector3.zero;
            var playerView = Object.Instantiate(_configuration.PlayerViewPrefab);
            playerEntity.Get<GameViewRef>().value = playerView;
            playerEntity.Get<Movement>().value = Vector3.forward;
            playerEntity.Get<AnimatorRef>().value = playerView.Animator;
        }
    }
}