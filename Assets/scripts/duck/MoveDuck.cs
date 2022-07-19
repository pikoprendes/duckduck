using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDuck : MonoBehaviour
{
    public float verSpeed = 7;
    public float verSpeedSave = 7;
    public float horSpeed = 10;
    private float horSpeedSave = 10;
    private float verticalFalling = -6.5f;

    private void Start()
    {
    }

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

    public void DeadDuck() //lanza la animacion del pato muerto y hace que no se mueva
    {
        gameObject.GetComponent<Animator>().SetBool("isDead", true);
        horSpeed = 0;
        verSpeed = 0;
    }

    public void DeactivateDuck() //al finalizar la animacion de morir desactivamos el pato y le devolvemos la velocidad originial para cuando vuelva a spawnearse
    {
        IsDuckInScene();
        gameObject.GetComponent<Animator>().SetBool("isDead", false);
        //gameObject.GetComponent<Rigidbody2D>().simulated = true;
        horSpeed = horSpeedSave;
        verSpeed = verSpeedSave;
        gameObject.SetActive(false);
    }

    public void DeadFallingDuck() //se activa durante la animacion
    {
        verSpeed = verticalFalling;
        //gameObject.GetComponent<Rigidbody2D>().simulated = false;
        int layerDeadDuck = LayerMask.NameToLayer("deadDuck");
        gameObject.layer = layerDeadDuck;
    }

    public void IsDuckInScene() //le comunica al spawner que ya no hay un pato en la escena
    {
        DuckSpawner duckSpawner = FindObjectOfType<DuckSpawner>();
        duckSpawner.duckInScene = false; //le decimos al duckSpawner que lance otro pato
    }
}