using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class PCGDungeon_GeneratorGameOfLife : MonoBehaviour
{

    [Header("Space Definition")]
    [SerializeField] private Vector2Int _size;
    [SerializeField][Range(0,1)] private float _bordersRatio = 0.0f;
    [SerializeField] Vector2Int _startPosition;

    [Header("Parameters")]
    [SerializeField][Range(0,1)] private float _initialFillRatio = 0.5f;
    [SerializeField] private int _maxIterations = 200;
    [SerializeField] private List<int> _stayAliveValues;
    [SerializeField] private List<int> _comeAliveValues;

    private HashSet<Vector2Int> _alivePositions = new HashSet<Vector2Int>();
    private HashSet<Vector2Int> _cavePositions = new HashSet<Vector2Int>();
    private BoundsInt _originalMap = new BoundsInt();
    private BoundsInt _fullMap = new BoundsInt();
    


    public HashSet<Vector2Int> Generate()
    {
        int oldPositionsCount = 0;
        int nbIterations = 0;
        
        SetMaps();

        _alivePositions = Initiate();
        
        // for (int iterations = 0; iterations < _maxIterations; iterations++)
        do
        {
            oldPositionsCount = _alivePositions.Count;
            _alivePositions = GameOfLifeIteration(_fullMap, _alivePositions);
            nbIterations++;
            
        } while (oldPositionsCount != _alivePositions.Count && nbIterations<=_maxIterations);
        
        _cavePositions = Invert(_fullMap, _alivePositions);

        List<HashSet<Vector2Int>> floodFills = CheckFloodFills();
        foreach (var floodFill in floodFills.OrderBy(ff => ff.Count))
        {
            if(floodFill != floodFills.OrderBy(ff => ff.Count).Last())
                _alivePositions.UnionWith(floodFill);
            
        }
        
        return _alivePositions;

    }

    public HashSet<Vector2Int> GetCave()
    {
        return _cavePositions;
    }
    
    public List<HashSet<Vector2Int>> CheckFloodFills()
    {

        List<HashSet<Vector2Int>> floodFills = new List<HashSet<Vector2Int>>();
        
        // Check flood fills
        HashSet<Vector2Int> checkPositions = new HashSet<Vector2Int>(_cavePositions);

        do
        {
            HashSet<Vector2Int> localHashSet = new HashSet<Vector2Int>();
            Vector2Int position = checkPositions.ElementAt(0);

            localHashSet.Add(position);
            AddFloodFill(position, _cavePositions, localHashSet);
            
            if (localHashSet.Count > 0)
            {
                floodFills.Add(localHashSet);

                foreach (Vector2Int i in localHashSet)
                {
                    checkPositions.Remove(i);
                }
            }
            
        } while (checkPositions.Count > 0);

        return floodFills;

    }

    private void AddFloodFill(Vector2Int position, HashSet<Vector2Int> checkPositions, HashSet<Vector2Int> currentFloodFill)
    {

        foreach (Vector2Int neighbourDirection in Neighbourhood.VonNeumann)
        {
            Vector2Int newPosition = position + neighbourDirection;

            if (checkPositions.Contains(newPosition) && !currentFloodFill.Contains(newPosition))
            {
                currentFloodFill.Add(newPosition);
                AddFloodFill(newPosition, checkPositions, currentFloodFill);
            }
                
        }
        
        return;
        
        int nbCount = Neighbourhood.getCount(position, _alivePositions, Neighbourhood.VonNeumann);
        
        // Check the flood
        if (nbCount >= 0)
        {
            // Add a flood fill
            currentFloodFill.Add(position);
            // Remove 
            checkPositions.Remove(position);
        }
    }

    private void SetMaps()
    {

        _fullMap = new BoundsInt(
            _startPosition.x - Mathf.FloorToInt(0.5f * _size.x), _startPosition.y - Mathf.FloorToInt(0.5f * _size.y), 0,
            _size.x, _size.y, 0);
        
        _originalMap = new BoundsInt(
            _startPosition.x - Mathf.FloorToInt(0.5f * (1.0f - _bordersRatio) * _size.x), _startPosition.y - Mathf.FloorToInt(0.5f * (1.0f - _bordersRatio) * _size.y), 0,
            Mathf.FloorToInt((1.0f - _bordersRatio) * _size.x),  Mathf.FloorToInt((1.0f - _bordersRatio) * _size.y), 0);

    }

    public HashSet<Vector2Int> GameOfLifeIterate()
    {
        _alivePositions = GameOfLifeIteration(_fullMap, _alivePositions);
        return _alivePositions;
    } 
    
    private HashSet<Vector2Int> GameOfLifeIteration(BoundsInt originalMap, HashSet<Vector2Int> alivePositions)
    {
        HashSet<Vector2Int> newPositions = new HashSet<Vector2Int>();
        
        // Iterate through each point, and log it to the Debug Console.
        for(int x = originalMap.xMin; x <= originalMap.xMax; x++)
        {
            for(int y = originalMap.xMin; y <= originalMap.xMax; y++)
            {
                Vector2Int my2DPosition = new Vector2Int(x, y);
            
                // l’état des cases est évalué
                bool isAlive = alivePositions.Contains(my2DPosition);
                // Le nombre de voisin de chaque case est compté
                int neighbourCount = Neighbourhood.getCount(my2DPosition, alivePositions, Neighbourhood.Moore);

                if (isAlive && _stayAliveValues.Contains(neighbourCount))
                {
                    // Si la case est vivante et qu’elle a 2-3 voisins vivant, elle reste vivante
                    newPositions.Add(my2DPosition);
                
                }else if (!isAlive == false && _comeAliveValues.Contains(neighbourCount))
                {
                    // Si la case est morte et qu’elle a 3 voisins vivants, elle devient vivante
                    newPositions.Add(my2DPosition);

                }
                else
                {
                    // Sinon elle considérée comme morte
                    // RIEN
                }
            }
        }

        return newPositions;

    }


    public HashSet<Vector2Int> Initiate()
    {

        HashSet<Vector2Int> positions = new HashSet<Vector2Int>();

        for(int x = _fullMap.xMin; x <= _fullMap.xMax; x++)
        {
            for(int y = _fullMap.xMin; y <= _fullMap.xMax; y++)
            {
                if ((x >= _originalMap.xMin && x <= _originalMap.xMax) &&
                    (y >= _originalMap.yMin && y <= _originalMap.yMax))
                {
                    // if in orginal map, add a position randomly
                    if(Random.value <= _initialFillRatio)
                        positions.Add(new Vector2Int(x, y));

                }
                else
                {
                    // If not , add it anyway
                    positions.Add(new Vector2Int(x, y));
                }
            }
        }
        
        return positions;

    }

    public HashSet<Vector2Int> Invert(BoundsInt referenceMap, HashSet<Vector2Int> positionsToInvert)
    {

        HashSet<Vector2Int> invertedPositions = new HashSet<Vector2Int>();

        for(int x = referenceMap.xMin; x <= referenceMap.xMax; x++)
        {
            for(int y = referenceMap.xMin; y <= referenceMap.xMax; y++)
            {
                Vector2Int my2DPosition = new Vector2Int(x, y);
                
                if (!positionsToInvert.Contains(my2DPosition))
                    invertedPositions.Add(my2DPosition);

            }
        }

        return invertedPositions;

    }


}
