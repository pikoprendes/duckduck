using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitScript : MonoBehaviour
{
    [SerializeField] private Manager managerPartida;

    void Start()
    {
        transform.GetComponent<Text>().text = managerPartida.hit.ToString();
    }

    
    void Update()
    {
        transform.GetComponent<Text>().text = managerPartida.hit.ToString();
    }
}
