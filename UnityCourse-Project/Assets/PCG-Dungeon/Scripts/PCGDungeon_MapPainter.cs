using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace PCGDungeon
{
    [ExecuteInEditMode]
    public class PCGDungeon_MapPainter : MonoBehaviour
    {

        [SerializeField] private Tilemap _floorMap;
        [SerializeField] private TileBase _floorTile;

        [SerializeField] private PCGDungeon_RandomWalk _rndWalkGenerator;
        
        public void RandomWalkGenerate()
        {
            _floorMap.ClearAllTiles();
            MapPaint(_rndWalkGenerator.Generate(), _floorMap, _floorTile);
        }

        private void MapPaint(IEnumerable<Vector2Int> positions, Tilemap map, TileBase tile)
        {
            foreach (Vector2Int position in positions)
            {
                CellPaint(map, tile, position);
            }
        }

        private static void CellPaint(Tilemap map, TileBase tile, Vector2Int position)
        {
            var mapPosition = map.WorldToCell((Vector3Int)position);
            map.SetTile(mapPosition, tile);
        }
    }
}
