using Leopotam.Ecs;
using UnityEngine;

namespace MarsRunner
{
    sealed class EcsStartup : MonoBehaviour
    {
        public Configuration Configuration;
        public SceneContext SceneContext;
        
        EcsWorld _world;
        EcsSystems _systems;

        void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
#endif
            _systems
                    
                .Add(new InitMapSystem())
                .Add(new SpawnPlayerSystem())
                .Add(new MovementSystem())
                .Add(new UpdateGameViewsSystem())
                .Add(new CameraUpdateSystem())
                .Add(new ResetOriginSystem())
                .Add(new InputSystem())
                .Add(new PlayerJumpSystem())
                .Add(new PlayerFallSystem())
                .Add(new AnimatorUpdateSystem())
                .Add(new ObstacleGenerationSystem())
                .Add(new CheckPlayerHitObstacleSystem())
                .Add(new CleanObstaclesSystem())
                .Add(new CheckGameOverSystem())
                .Add(new UpdateScoreSystem())
                .Add(new UpdateUISystem())
                
                .Inject(Configuration)
                .Inject(SceneContext)
                .Inject(new GameState(Configuration))

                .OneFrame<Animation>()
                .OneFrame<EndGameEvent>()
                
                .Init();
        }
        
        void Update()
        {
            _systems?.Run();
        }

        void OnDestroy()
        {
            if (_systems != null)
            {
                _systems.Destroy();
                _systems = null;
                _world.Destroy();
                _world = null;
            }
        }
    }
}