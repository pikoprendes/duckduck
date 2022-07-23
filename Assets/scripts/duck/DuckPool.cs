using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckPool : MonoBehaviour
{

    [SerializeField] private GameObject duckPrefab;
    [SerializeField] private int poolSize = 3;

    private Queue<GameObject> objectQueue;
    
    void Start()
    {
        objectQueue = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject poolObject = Instantiate(duckPrefab, transform.position, Quaternion.identity);
            poolObject.transform.SetParent(transform);
            objectQueue.Enqueue(poolObject);
            poolObject.SetActive(false);
        }

    }


    public GameObject getDuckFromPool(Vector3 position, Quaternion rotation)
    {
        GameObject poolObject = objectQueue.Dequeue();
        poolObject.SetActive(true);
        poolObject.transform.position = position;
        poolObject.transform.rotation = rotation;
        objectQueue.Enqueue(poolObject);
        return poolObject;
    }
}
