using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckSpawner : MonoBehaviour
{
    [SerializeField] private PlayerShoot playerShoot;
    [SerializeField] private DuckPool[] myDuckPools;
    [SerializeField] private Transform[] spawnPositions;
    public bool duckInScene = false;
    public bool canISpawn = false;
    [SerializeField] private float timetoSpawn = 2.5f;
    private Manager manager;

    private void Start()
    {
        manager = FindObjectOfType<Manager>();
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
        int randomPoolSelector = Random.Range(0, myDuckPools.Length);
        GameObject pooledDuck = myDuckPools[randomPoolSelector].getDuckFromPool(spawnPositions[randomSpawnPosSelector].position, spawnPositions[randomSpawnPosSelector].rotation);
    }

    public IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(timetoSpawn); //esperamos x segundos para spawnear
        if (!manager.isDuck10)
        {
            Spawner();
            playerShoot.canIShoot = true; //le comunicamos al jugador que ya puede disparar
            playerShoot.StopAllCoroutineFunction();
            playerShoot.TimeCounterFunction();
            canISpawn = true;
        }     
    }
}