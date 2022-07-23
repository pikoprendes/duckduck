using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RondaScript : MonoBehaviour
{
    [SerializeField] private Manager managerPartida;
    
    void Start()
    {
        transform.GetComponent<Text>().text = managerPartida.ronda.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetComponent<Text>().text = managerPartida.ronda.ToString();
    }
}
