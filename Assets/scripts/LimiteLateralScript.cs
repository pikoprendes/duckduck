using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimiteLateralScript : MonoBehaviour
{
    public LayerMask playerMask;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Utils.IsInLayerMask(collision.gameObject, playerMask))
        {
            MoveDuck moveDuck = collision.gameObject.GetComponent<MoveDuck>();
            if (moveDuck.horSpeed > 0)
                moveDuck.horSpeed = -moveDuck.horSpeed;
            else
                moveDuck.horSpeed *= -1;
        }
    }

}
