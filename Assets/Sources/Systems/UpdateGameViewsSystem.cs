using Leopotam.Ecs;

namespace MarsRunner
{
    public class UpdateGameViewsSystem : IEcsRunSystem
    {
        private readonly EcsFilter<GameViewRef, Position> _filter;

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var gameView = ref _filter.Get1(index);
                gameView.value.transform.position = _filter.Get2(index).value;
            }
        }
    }
}