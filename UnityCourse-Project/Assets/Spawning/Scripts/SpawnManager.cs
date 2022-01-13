using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private Mob mobToSpawn;

    [SerializeField]
    private List<Transform> spawnPoints;

    private List<Mob> Mobs;
    
    // Start is called before the first frame update
    void Start()
    {
        Mobs = new List<Mob>();

        for (int i = 0; i < spawnPoints.Count; i++)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count - 1)];
            Mob newMob = Instantiate<Mob>(mobToSpawn, spawnPoint.position, spawnPoint.rotation);
            //Mobs.Add(newMob);
        }
    }

    // Update is called once per frame
    void Update()
    {
/*        for (int i = Mobs.Count - 1; i >= 0 ; i--)
        {
            Mob myMob = Mobs[i];
            if(myMob.Health <= 0)
            {
                Mobs.RemoveAt(i);
                myMob.Kill();
            }
        }*/

    }

}
