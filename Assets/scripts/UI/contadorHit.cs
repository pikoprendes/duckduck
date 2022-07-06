using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class contadorHit : MonoBehaviour
{
    public Manager managerPartida;

    void Start()
    {
        transform.GetComponent<Text>().text = managerPartida.contadorHit.ToString();
    }

    
    void Update()
    {
        transform.GetComponent<Text>().text = managerPartida.contadorHit.ToString();
    }
}
