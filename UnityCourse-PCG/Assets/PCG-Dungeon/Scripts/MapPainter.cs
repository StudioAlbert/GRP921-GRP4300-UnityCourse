using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace PCGDungeon
{
    public class MapPainter
    {
        private void MapPaint(IEnumerable<Vector2Int> positions, Tilemap map, TileBase tile)
        {
            foreach (Vector2Int position in positions)
            {
                CellPaint(position, map, tile);
            }

        }

        private void MapPaint(IEnumerable<Vector2Int> positions, Tilemap map, RuleTile tile)
        {
            foreach (Vector2Int position in positions)
            {
                CellPaint(position, map, tile);
            }
        }

        private static void CellPaint(Vector2Int position, Tilemap map, TileBase tile)
        {
            var mapPosition = map.WorldToCell((Vector3Int)position);
            map.SetTile(mapPosition, tile);
        }

        private static void CellPaint(Vector2Int position, Tilemap map, RuleTile tile)
        {
            var mapPosition = map.WorldToCell((Vector3Int)position);
            map.SetTile(mapPosition, tile);
        }
    }
}
