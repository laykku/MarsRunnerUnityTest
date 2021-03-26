using Leopotam.Ecs;
using UnityEngine;

namespace MarsRunner
{
    public class PlayerJumpSystem : IEcsRunSystem
    {
        private EcsFilter<Jump, Position> _filter;
        private readonly Configuration _configuration;

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var jump = ref _filter.Get1(index);
                ref var position = ref _filter.Get2(index);
                
                jump.value += Time.deltaTime * _configuration.JumpSpeed;
                position.value.y = jump.value;

                if (jump.value >= _configuration.JumpHeight)
                {
                    _filter.GetEntity(index).Del<Jump>();
                    _filter.GetEntity(index).Get<Fall>().value = _configuration.JumpHeight;
                }
            }
        }
    }
}