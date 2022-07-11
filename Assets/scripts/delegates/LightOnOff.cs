using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnOff : MonoBehaviour
{
    // Start is called before the first frame update
    public Light light;
    public PressurePlate pressurePlate;
    void Start()
    {
        pressurePlate.OnRightWeight += LightOn;
        pressurePlate.OnWrongWeight += LightOff;
    }

    public void LightOn()
    {
        light.enabled = true;
    }

    public void LightOff()
    {
        light.enabled = false;
    }
}
