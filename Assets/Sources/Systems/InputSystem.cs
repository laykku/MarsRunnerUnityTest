using Leopotam.Ecs;
using UnityEngine;

namespace MarsRunner
{
    public class InputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Player>.Exclude<Jump, Fall> _filter;

        private static readonly int Jump = Animator.StringToHash("Jump");

        public void Run()
        {
            foreach (var index in _filter)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _filter.GetEntity(index).Get<Jump>();
                    _filter.GetEntity(index).Get<Animation>().value = Jump;
                }
            }
        }
    }
}