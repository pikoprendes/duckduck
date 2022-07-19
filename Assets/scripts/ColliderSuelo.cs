using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderSuelo : MonoBehaviour
{
    public LayerMask playerMask;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Utils.IsInLayerMask(collision.gameObject, playerMask))
        {
            Debug.Log("First point that collided: " + collision.contacts[0].point);
        }
        Physics2D.IgnoreLayerCollision(0, 6, true);
    }
}