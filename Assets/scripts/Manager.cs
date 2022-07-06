using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public int ronda = 1;
    public int score = 0;
    public int contadorHit = 0;
    public int hit = 0;

    void Start()
    {
        ronda = 1;
        score = 0;
        hit = 0;
        contadorHit = 0;
}

    // Update is called once per frame
    void Update()
    {
        if (contadorHit == 9)
        {
            hit = 0;
            contadorHit = 0;
            ronda++;
        }
    }

    public void MissedTarget()
    {
        contadorHit++;
    }
}
