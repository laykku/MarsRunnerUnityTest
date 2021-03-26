using Leopotam.Ecs;
using UnityEngine;

namespace MarsRunner
{
    public class CheckGameOverSystem : IEcsRunSystem
    {
        private readonly EcsFilter<EndGameEvent> _filter;
        private readonly EcsFilter<GameViewRef, Player> _playerFilter;
        
        private readonly SceneContext _sceneContext;
        private readonly GameState _gameState;
        
        public void Run()
        {
            if (!_filter.IsEmpty())
            {
                _gameState.IsPlaying = false;

                Object.DestroyImmediate(_playerFilter.Get1(0).value.gameObject);
                _playerFilter.GetEntity(0).Destroy();

                int highScore = 0;
                if (PlayerPrefs.HasKey(Configuration.HighScoreToken))
                {
                    highScore = PlayerPrefs.GetInt(Configuration.HighScoreToken);
                }

                if (_gameState.Score > highScore) highScore = _gameState.Score;
                
                PlayerPrefs.SetInt(Configuration.HighScoreToken, highScore);
                
                _sceneContext.UI.gameOverScreen.SetScore(_gameState.Score);
                _sceneContext.UI.gameOverScreen.Show(true);
            }
        }
    }
}