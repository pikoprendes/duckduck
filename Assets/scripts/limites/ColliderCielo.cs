using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCielo : MonoBehaviour
{
    [SerializeField] private LayerMask duckMask;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Utils.IsInLayerMask(collision.gameObject, duckMask))
        {
            DuckPoints duckPoints = FindObjectOfType<DuckPoints>();
            duckPoints.DisableCieloRosa();
            duckPoints.DeactivateDuck();
            DogScript dog2 = FindObjectOfType<DogScript>();
            dog2.DogLaughing();
        }
    }
}