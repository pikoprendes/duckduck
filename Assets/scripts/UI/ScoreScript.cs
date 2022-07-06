using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Manager managerPartida;

    void Start()
    {
        transform.GetComponent<Text>().text = managerPartida.score.ToString();
    }

    
    void Update()
    {
        transform.GetComponent<Text>().text = managerPartida.score.ToString();
    }
}
