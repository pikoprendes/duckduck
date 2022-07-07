using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDuck : MonoBehaviour
{
    public float verSpeed;
    public float horSpeed;

    private void Start()
    {
        horSpeed = Random.Range(-10, 10);
        verSpeed = Random.Range(2, 4);
    }

    // Update is called once per frame
    private void Update()
    {
        DuckMovement();
        FlipDuck();
    }

    public void DuckMovement()
    {
        transform.position += new Vector3(horSpeed * Time.deltaTime, verSpeed * Time.deltaTime, 0);
    }

    public void FlipDuck()
    {
        if (horSpeed >= 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    public void DeadDuck()
    {
        gameObject.GetComponent<Animator>().SetBool("isDead", true);
        horSpeed = 0;
        verSpeed = 0;
        gameObject.GetComponent<Collider2D>().enabled = false;
    }

    public void DeactivateDuck()
    {
        gameObject.SetActive(false);
        IsDuckInScene();
        ResetDuck();
    }

    public void DeadFallingDuck()
    {
        verSpeed = -3;
    }

    public void ResetDuck()
    {
        gameObject.GetComponent<Animator>().SetBool("isDead", false);
        gameObject.GetComponent<Collider2D>().enabled = true;
        horSpeed = Random.Range(-10, 10);
        verSpeed = Random.Range(2, 4);
    }

    public void IsDuckInScene()
    {
        DuckSpawner duckSpawner = FindObjectOfType<DuckSpawner>();
        duckSpawner.duckInScene = false; //le decimos al duckSpawner que lance otro pato
    }
}