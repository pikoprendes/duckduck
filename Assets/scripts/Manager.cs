using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public int ronda;
    public int rondaSet = 1;
    public int score;
    public int scoreSet = 0;
    public int duckCounter; //cuenta los patos totales
    public int duckCounterSet = 0;
    public int hit; //cuenta los patos que se han abatido
    public int hitSet = 0;
    public Transform[] redDucks;
    public Transform[] whiteDucks;
    public bool changeRound = false;
    private PlayerShoot player;
    private DuckSpawner duckSpawner;

    private void Start()
    {
        ronda = rondaSet;
        score = scoreSet;
        hit = hitSet;
        duckCounter = duckCounterSet;
        changeRound = true;
        player = FindObjectOfType<PlayerShoot>();
        duckSpawner = FindObjectOfType<DuckSpawner>();
    }

    private void Update()
    {
        if (duckCounter == 10)
        {
            NextRound();
            //corrutina que parpadee los sprites y saque depsues el round sign
            changeRound = true;
        }
    }

    public void MissedTarget()
    {
        duckCounter++; //no hemoss abatido el pato pero sube el contador de patos
    }

    public void TargetHit()
    {
        ShowRedDuck(duckCounter);//mostramos el pato rojo en señal que lo hemos alcanzado
        hit++; //hemos abatido al pato
        duckCounter++; //un pato mas
    }

    public void NextRound()
    {
        player.canIShoot = false; //le comunicamos al jugador que no puede disparar
        duckSpawner.canISpawn = false;
        ResetRedDucks();
        StartCoroutine(BlinkinRedDucksCor());
        //hit = hitSet; //cambiar
        //duckCounter = duckCounterSet; //cambiar
        //ResetRedDucks(); //cambiar
        //ronda++;
    }

    public void ShowRedDuck(int contadorHit) //muestra el pato rojo si hemos alcanzado al pato en el lugar que corresponde
    {
        redDucks[contadorHit].gameObject.SetActive(true);
    }

    public void ResetRedDucks() //oculta todos los patos rojos al acabar cada ronda
    {
        for (int i = 0; i < redDucks.Length; i++)
        {
            redDucks[i].gameObject.SetActive(false);
        }
    }

    public IEnumerator BlinkinRedDucksCor()
    {
        float elapsedTime = 0;
        while (elapsedTime > 5)
        {
            elapsedTime += Time.deltaTime;
            ActivateBlinkinRedDucks();
            yield return new WaitForSeconds(0.5f);
            DeactivateBlinkinRedDucks();
        }
    }

    public void ActivateBlinkinRedDucks() //metodo para final de ronda que hace parpadear los sprites rojos del pato
    {
        for (int i = 0; i < hit; i++)
        {
            redDucks[i].gameObject.SetActive(true);
        }
    }

    public void DeactivateBlinkinRedDucks() //metodo para final de ronda que hace parpadear los sprites rojos del pato
    {
        for (int i = 0; i < hit; i++)
        {
            redDucks[i].gameObject.SetActive(false);
        }
    }
}