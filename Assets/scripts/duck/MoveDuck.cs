using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveDuck : MonoBehaviour
{
    public float verSpeed = 7;
    public float verSpeedSave = 7;
    public float horSpeed = 10;
    public float horSpeedSave = 10;
    public Text puntuacionPato;

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
        gameObject.GetComponentInChildren<Animator>().SetBool("isDead", true);
        horSpeed = 0;
        verSpeed = 0;
        puntuacionPato.transform.gameObject.SetActive(true);
        puntuacionPato.transform.position = gameObject.transform.position;
        puntuacionPato.text = 1000.ToString();
    }

    public void IsDuckInScene() //le comunica al spawner que ya no hay un pato en la escena
    {
        DuckSpawner duckSpawner = FindObjectOfType<DuckSpawner>();
        duckSpawner.duckInScene = false; //le decimos al duckSpawner que lance otro pato
    }

    public void DeactivateParent()
    {
        gameObject.SetActive(false);
    }
}