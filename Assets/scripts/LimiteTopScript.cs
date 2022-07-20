using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimiteTopScript : MonoBehaviour
{
    public LayerMask duckMask, duckMask2;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Utils.IsInLayerMask(collision.gameObject, duckMask))
        {
            MoveDuck moveDuck = collision.gameObject.GetComponent<MoveDuck>();
            moveDuck.verSpeed *= -1;
        }
        Physics2D.IgnoreLayerCollision(0, 8, true);
    }

}