using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCielo : MonoBehaviour
{
    public LayerMask duckMask;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Utils.IsInLayerMask(collision.gameObject, duckMask))
        {
            MoveDuck moveDuck = collision.gameObject.GetComponent<MoveDuck>();
            moveDuck.DisableCieloRosa();
            moveDuck.DeactivateDuck();
            DogScript dog2 = FindObjectOfType<DogScript>();
            dog2.DogLaughing();
        }
    }
}