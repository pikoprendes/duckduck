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
    public int timetoSpawn = 2;

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
            yield return new WaitForSeconds(timetoSpawn); //esperamos x segundos para spawnear
            //yield return null;
            if (canISpawn && !duckInScene) //si puedo spawnear y no hay un pato en la escena lo saco
            {
                Spawner();
                playerShoot.canIShoot = true; //le comunicamos al juagdor que ya puede disparar
            }
        }
    }
}