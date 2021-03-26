using Leopotam.Ecs;

namespace MarsRunner
{
    public class AnimatorUpdateSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Animation, AnimatorRef> _animators;
        
        public void Run()
        {
            foreach (var index in _animators)
            {
                var animator = _animators.Get2(index).value;
                var animation = _animators.Get1(index).value;
                animator.SetTrigger(animation);
            }    
        }
    }
}