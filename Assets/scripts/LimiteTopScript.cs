using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimiteTopScript : MonoBehaviour
{
    public LayerMask playerMask;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Utils.IsInLayerMask(collision.gameObject, playerMask))
        {
            MoveDuck moveDuck = collision.gameObject.GetComponent<MoveDuck>();
            moveDuck.verSpeed *= -1;
            moveDuck.horSpeed = Random.Range(-3, 3);
        }
    }
}