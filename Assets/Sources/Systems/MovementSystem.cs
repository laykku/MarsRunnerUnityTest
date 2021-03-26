using Leopotam.Ecs;
using UnityEngine;

namespace MarsRunner
{
    public class MovementSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Position, Movement> _filter;
        private readonly GameState _gameState;
        
        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var position = ref _filter.Get1(index);
                position.value += _filter.Get2(index).value * _gameState.PlayerMovementSpeed * Time.deltaTime;
            }
        }
    }
}