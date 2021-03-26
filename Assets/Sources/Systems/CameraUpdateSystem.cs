using Leopotam.Ecs;

namespace MarsRunner
{
    public class CameraUpdateSystem : IEcsRunSystem
    {
        private readonly EcsFilter<GameViewRef, Player> _filter;
        private readonly Configuration _configuration;
        private readonly SceneContext _sceneContext;
        
        public void Run()
        {
            foreach (var index in _filter)
            {
                var playerView = _filter.Get1(index).value;
                var position = playerView.transform.position;
                _sceneContext.CameraTransform.position = position + _configuration.CameraOffset;
                _sceneContext.CameraTransform.LookAt(position + _configuration.CameraLookTarget);
            }
        }
    }
}