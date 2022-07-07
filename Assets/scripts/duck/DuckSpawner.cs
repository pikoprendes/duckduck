using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckSpawner : MonoBehaviour
{
    public DuckPool myDuckPool;
    public Transform[] spawnPositions;
    public bool duckInScene = false;
    public bool canISpawn = false;
    public int timetoSpawn = 2;

    //public RoundSign.states currentState;

    private void Start()
    {
        canISpawn = false;
        StartCoroutine(SpawnRoutine());
    }

    public void Spawner()
    {
        duckInScene = true;
        int randomSpawnPosSelector = Random.Range(0, spawnPositions.Length);
        GameObject pooledDuck = myDuckPool.getDuckFromPool(spawnPositions[randomSpawnPosSelector].position, spawnPositions[randomSpawnPosSelector].rotation);
    }

    public IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(timetoSpawn);
            //yield return null;
            if (canISpawn && !duckInScene)
            {
                Spawner();
            }
        }
    }
}