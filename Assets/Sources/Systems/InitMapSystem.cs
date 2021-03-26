using Leopotam.Ecs;
using UnityEngine;

namespace MarsRunner
{
    public class InitMapSystem : IEcsInitSystem
    {
        private readonly Configuration _configuration;
        private readonly EcsWorld _world;
        
        public void Init()
        {
            for (int i = 0; i < _configuration.MapLength; i++)
            {
                var mapTile = _world.NewEntity();
                mapTile.Get<MapTile>();

                var mapTileView = Object.Instantiate(_configuration.MapTilePrefab);;
                mapTile.Get<MapTileViewRef>().value = mapTileView;

                mapTileView.transform.position = new Vector3(0f, 0f, i * _configuration.MapTileSide);
            }
        }
    }
}