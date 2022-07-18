using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    public float KilosInPlate;
    public float TargetKilos;

    public System.Action OnRightWeight;
    public System.Action OnWrongWeight;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            KilosInPlate += rb.mass;
            CheckWeight();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            KilosInPlate -= rb.mass;
            CheckWeight();
        }
    }


    public void CheckWeight()
    {
        if (KilosInPlate >= TargetKilos)
        {
            if (OnRightWeight != null)
            {
                OnRightWeight();
                
            }
        }
        else
        {
            if (OnWrongWeight != null)
            {
                OnWrongWeight();
            }
        }
    }

}
