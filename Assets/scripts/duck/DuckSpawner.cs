using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckSpawner : MonoBehaviour
{
    public PlayerShoot playerShoot;
    public DuckPool myDuckPool;
    public Transform[] spawnPositions;
    public bool duckInScene = false;
    public bool canISpawn = false;
    public float timetoSpawn = 2.5f;

    private void Start()
    {
        canISpawn = false;
    }

    private void Update()
    {
        if (canISpawn && !duckInScene)
        {
            canISpawn = false;
            StartCoroutine(SpawnRoutine());
        }
    }

    public void Spawner()
    {
        duckInScene = true;
        int randomSpawnPosSelector = Random.Range(0, spawnPositions.Length);
        GameObject pooledDuck = myDuckPool.getDuckFromPool(spawnPositions[randomSpawnPosSelector].position, spawnPositions[randomSpawnPosSelector].rotation);
    }

    public IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(timetoSpawn); //esperamos x segundos para spawnear
        Spawner();
        playerShoot.canIShoot = true; //le comunicamos al jugador que ya puede disparar
        playerShoot.StopAllCoroutineFunction();
        playerShoot.TimeCounterFunction();
        canISpawn = true;
    }
}