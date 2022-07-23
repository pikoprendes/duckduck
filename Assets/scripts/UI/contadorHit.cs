using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class contadorHit : MonoBehaviour
{
    [SerializeField] private Manager managerPartida;

    private void Start()
    {
        transform.GetComponent<Text>().text = managerPartida.duckCounter.ToString();
    }

    private void Update()
    {
        transform.GetComponent<Text>().text = managerPartida.duckCounter.ToString();
    }
}