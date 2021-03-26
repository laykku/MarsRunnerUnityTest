using Leopotam.Ecs;

namespace MarsRunner
{
    public class UpdateUISystem : IEcsRunSystem
    {
        private readonly GameState _gameState;
        private readonly SceneContext _sceneContext;
        
        public void Run()
        {
            _sceneContext.UI.ScoreLabel.text = $"SCORE: {_gameState.Score}";
        }
    }
}