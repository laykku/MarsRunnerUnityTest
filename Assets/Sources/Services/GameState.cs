namespace MarsRunner
{
    public class GameState
    {
        private readonly Configuration _configuration;
        public float PlayerMovementSpeed { get; private set; }
        public float LastObstacleAppearTime;
        public float NextObstacleGeneration = 2f;
        public int Score { get; set; }
        public float ScoreUpdateTimeStamp { get; set; }
        public bool IsPlaying { get; set; } = true;
        
        public GameState(Configuration configuration)
        {
            _configuration = configuration;
            PlayerMovementSpeed = _configuration.InitialPlayerSpeed;
        }
    }
}