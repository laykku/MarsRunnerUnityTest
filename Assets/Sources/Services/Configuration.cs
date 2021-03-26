using UnityEngine;

namespace MarsRunner
{
    [CreateAssetMenu(fileName = "Configuration")]
    public class Configuration : ScriptableObject
    {
        public const string HighScoreToken = "_highScore";

        [Header("Object prefabs")]
        public PlayerView PlayerViewPrefab;
        public ObstacleView ObstacleViewPrefab;
        public MapTileView MapTilePrefab;
        
        public Vector3 CameraOffset = new Vector3(0f, .5f, -1f);
        public Vector3 CameraLookTarget = new Vector3(0f, .5f, 1f);
        
        [Header("Gameplay settings")]
        public float ResetOriginDistance = 5f;
        public int ScoreBonusPerSecond = 100;
        
        [Header("Player settings")]
        public float JumpHeight = 2f;
        public float JumpSpeed = 2.5f;
        public float FallSpeed = 2.5f;
        public float InitialPlayerSpeed = 1f;

        [Header("Map settings")]
        public int MapLength = 10;
        public float MapTileSide = 10f;

        [Header("Obstacle generation settings")]
        public float ObstacleAppearChance = 0.3f;
        public Vector2 ObstacleGenRangeBounds = new Vector2(2f, 5f);
        public Vector2 ObstacleGenTimeRange = new Vector2(1f, 3f);
    }
}