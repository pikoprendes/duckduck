using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDuck : MonoBehaviour
{

    public float verSpeed;
    public float horSpeed;
    void Start()
    {
        horSpeed = Random.Range(-3, 3);
    }

    // Update is called once per frame
    void Update()
    {
        DuckMovement();
    }

    public void DuckMovement()
    {
        transform.position += new Vector3(horSpeed * Time.deltaTime, verSpeed * Time.deltaTime, 0);
    }
}
