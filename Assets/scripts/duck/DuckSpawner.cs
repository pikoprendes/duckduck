using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckSpawner : MonoBehaviour
{
    public DuckPool myDuckPool;
    public Transform[] spawnPositions;
    public bool duckInScene = false;



    void Update()
    {
        if (!duckInScene)
        {
            Spawner();
        }
    }

    public void Spawner()
    {
        duckInScene = true;
        int randomSpawnPosSelector = Random.Range(0, spawnPositions.Length);
        GameObject pooledDuck = myDuckPool.getDuckFromPool(spawnPositions[randomSpawnPosSelector].position, spawnPositions[randomSpawnPosSelector].rotation);
    }
}
