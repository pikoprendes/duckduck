using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalasCounter : MonoBehaviour
{
    [SerializeField] private PlayerShoot player;

    void Start()
    {
        transform.GetComponent<Text>().text = player.balas.ToString();
    }


    void Update()
    {
        transform.GetComponent<Text>().text = player.balas.ToString();
    }
}
