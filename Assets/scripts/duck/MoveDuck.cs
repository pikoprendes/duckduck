//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDuck : MonoBehaviour
{
    public float verSpeed = 7;
    public float verSpeedSave = 7;
    public float horSpeed = 10;
    public float horSpeedSave = 10;
    private float verticalFalling = -6.5f;
    private float flyingAwaySpeed = 10f;
    private GameObject cieloRosa;
    [SerializeField] private AudioSource audio1, audio2, audio3;
    public int duckPoints = 500;
    public int health;
    private int healthSave;


    private void Start()
    {
        healthSave = health;
        cieloRosa = GameObject.FindGameObjectWithTag("cieloRosa");
    }

    private void Update()
    {
        DuckMovement();
        FlipDuck();
    }

    public void QuackSound() 
    {
        int randomNumber = Random.Range(0, 31);
        if (randomNumber == 15)
        {
            audio2.Play();
        }
    }

    private void OnEnable()
    {
        int layerDeadDuck = LayerMask.NameToLayer("duck");
        gameObject.layer = layerDeadDuck;
        audio1.Play();
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
        audio1.Stop();
        gameObject.GetComponent<Animator>().SetBool("isDead", true);
        horSpeed = 0;
        verSpeed = 0;  
    }

    public void DeactivateDuck() //al finalizar la animacion de morir desactivamos el pato y le devolvemos la velocidad originial para cuando vuelva a spawnearse
    {
        NoDuckInScene();
        gameObject.GetComponent<Animator>().SetBool("isDead", false);
        gameObject.GetComponent<Animator>().SetBool("hasEscaped", false);
        health = healthSave;
        horSpeed = horSpeedSave;
        verSpeed = verSpeedSave;
        gameObject.GetComponent<SpriteRenderer>().flipX = false;
        gameObject.SetActive(false);
    }

    public void DeadFallingDuck() //se activa durante la animacion
    {
        verSpeed = verticalFalling;
        //gameObject.GetComponent<Rigidbody2D>().simulated = false;
        int layerDeadDuck = LayerMask.NameToLayer("deadDuck");
        gameObject.layer = layerDeadDuck;
    }
    public void DuckFallingSound()
    {
        audio3.Play();
    }

    public void DuckFlyingAway() //Metodo para cuando no se ha matado al pato o han pasado mas de x segundos
    {
        audio1.Stop();
        horSpeed = 0;
        verSpeed = flyingAwaySpeed;
        gameObject.GetComponent<Animator>().SetBool("hasEscaped", true);
        int layerFlyingAwayDuck = LayerMask.NameToLayer("flyingAwayDuck");
        gameObject.layer = layerFlyingAwayDuck;
    }

    public void NoDuckInScene() //le comunica al spawner que ya no hay un pato en la escena
    {
        DuckSpawner duckSpawner = FindObjectOfType<DuckSpawner>();
        duckSpawner.duckInScene = false; //le decimos al duckSpawner que lance otro pato
    }

    public void EnableCieloRosa()
    {
        cieloRosa.GetComponent<SpriteRenderer>().sortingOrder = 1;
    }

    public void DisableCieloRosa()
    {
        cieloRosa.GetComponent<SpriteRenderer>().sortingOrder = -1;
    }
    public int ReturnDuckPoints()
    {
        return duckPoints;
    }

}