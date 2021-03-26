using System.Collections;
using Leopotam.Ecs;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace MarsRunner.Tests
{
    public class GameLogicTests
    {
        [UnityTest]
        public IEnumerator TestWithoutMovement()
        {
            CreateWorld(out var world, out var systems, out var config);

            systems
                .Add(new MovementSystem())
                .Inject(new GameState(config))
                .Init();
            
            var playerEntity = world.NewEntity();
            playerEntity.Get<Player>();
            playerEntity.Get<Position>();

            for (int i = 0; i < 100; i++)
            {
                systems.Run();
                yield return new WaitForEndOfFrame();
            }

            var playerPos = playerEntity.Get<Position>().value.z;
            
            ClearWorld(world, systems);
            
            Assert.AreEqual(0, playerPos);
        }
        
        [UnityTest]
        public IEnumerator TestMovement()
        {
            CreateWorld(out var world, out var systems, out var config);

            systems
                .Add(new MovementSystem())
                .Inject(new GameState(config))
                .Init();
            
            var playerEntity = world.NewEntity();
            playerEntity.Get<Player>();
            playerEntity.Get<Position>();
            playerEntity.Get<Movement>().value = Vector3.forward;

            for (int i = 0; i < 100; i++)
            {
                systems.Run();
                yield return new WaitForEndOfFrame();
            }

            var playerPos = playerEntity.Get<Position>().value.z;
            
            ClearWorld(world, systems);
            
            Assert.Greater(playerPos, 0f);
        }
        
        [UnityTest]
        public IEnumerator TestScoreIncreased()
        {
            CreateWorld(out var world, out var systems, out var config);

            var gameState = new GameState(config);
            
            systems
                .Add(new MovementSystem())
                .Add(new UpdateScoreSystem())
                .Inject(config)
                .Inject(gameState)
                .Init();
            
            for (int i = 0; i < 100; i++)
            {
                systems.Run();
                yield return new WaitForEndOfFrame();
            }

            int score = gameState.Score;
            
            ClearWorld(world, systems);
            
            Assert.Greater(score, 0);
        }
        
        private static void CreateWorld(out EcsWorld world, out EcsSystems systems, out Configuration config)
        {
            world = new EcsWorld();
            systems = new EcsSystems(world);
            config = ScriptableObject.CreateInstance<Configuration>();
        }

        private static void ClearWorld(EcsWorld world, EcsSystems systems)
        {
            systems.Destroy();
            world.Destroy();
        }
    }
}