using Leopotam.Ecs;
using UnityEngine;

namespace MarsRunner
{
    public class UpdateScoreSystem : IEcsRunSystem
    {
        private readonly GameState _gameState;
        private Configuration _configuration;

        public void Run()
        {
            if (_gameState.IsPlaying && Time.time - _gameState.ScoreUpdateTimeStamp >= .05f)
            {
                _gameState.ScoreUpdateTimeStamp = Time.time;
                _gameState.Score += _configuration.ScoreBonusPerSecond / 20;
            }
        }
    }
}