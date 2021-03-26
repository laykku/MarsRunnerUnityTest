using Leopotam.Ecs;
using UnityEngine;

namespace MarsRunner
{
    public class PlayerFallSystem : IEcsRunSystem
    {
        private EcsFilter<GameViewRef, Fall, Position, Player> _filter;
        private readonly Configuration _configuration;

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var fall = ref _filter.Get2(index);
                ref var position = ref _filter.Get3(index);
                
                fall.value -= Time.deltaTime * _configuration.FallSpeed;
                position.value.y = fall.value;

                if (fall.value <= 0f)
                {
                    position.value.y = 0f;
                    _filter.GetEntity(index).Del<Fall>();
                }
            }
        }
    }
}