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

    private void Start()
    {
        ronda = rondaSet;
        score = scoreSet;
        hit = hitSet;
        duckCounter = duckCounterSet;
        changeRound = true;
    }

    private void Update()
    {
        if (duckCounter == 10)
        {
            NextRound();
            changeRound = true;
        }
    }

    public void MissedTarget()
    {
        duckCounter++; //no hemoss abatido el pato pero sube el contador de patos
    }

    public void NextRound()
    {
        hit = hitSet;
        duckCounter = duckCounterSet;
        ResetRedDucks();
        ronda++;
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
}