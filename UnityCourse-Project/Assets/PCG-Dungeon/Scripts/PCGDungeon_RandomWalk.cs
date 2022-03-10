using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace PCGDungeon
{
    public class PCGDungeon_RandomWalk : MonoBehaviour
    {

        [SerializeField] private Vector2Int _startPosition;
        [SerializeField] private int _walkLength = 10;
        [SerializeField] private int _iterations = 10;
        [SerializeField] private bool _restartAtRandomPositions = false;

        private List<Vector2Int> _walkDirections = new List<Vector2Int>
        {
            new Vector2Int(0, 1), // Full Up
            new Vector2Int(1, 0), // Full Right
            new Vector2Int(0, -1), // Full down
            new Vector2Int(-1, 0) // Full left

        };  
        private Vector2Int GetWalkDirection()
        {
            return _walkDirections[Random.Range(0, _walkDirections.Count)];
        }
        
        public HashSet<Vector2Int> Generate()
        {
            Vector2Int currentPosition = _startPosition;
            HashSet<Vector2Int> positions = new HashSet<Vector2Int>();

            for (int iter = 0; iter < _iterations; iter++)
            {
                positions.UnionWith(SimpleRandomWalk(currentPosition, _walkLength));
                if (_restartAtRandomPositions)
                    currentPosition = positions.ElementAt(Random.Range(0, positions.Count));
                
            }

            return positions;
        }

        private HashSet<Vector2Int> SimpleRandomWalk(Vector2Int startPosition, int walkLength)
        {
            
            HashSet<Vector2Int> theWalk = new HashSet<Vector2Int>();
            
            theWalk.Add(startPosition);
            Vector2Int previousPosition = startPosition;

            for (int step = 0; step < walkLength; step++)
            {
                Vector2Int newPosition = previousPosition + GetWalkDirection();
                theWalk.Add(newPosition);
                previousPosition = newPosition;
            }
            
            return theWalk;
        }

    }
}
