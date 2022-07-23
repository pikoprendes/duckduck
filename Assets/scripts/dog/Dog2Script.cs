using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog2Script : MonoBehaviour
{

    public void PlayAudio3Barks()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}
