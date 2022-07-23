using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimiteLateralScript : MonoBehaviour
{
    [SerializeField] private LayerMask playerMask;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Utils.IsInLayerMask(collision.gameObject, playerMask))
        {
            DuckPoints duckPoints = collision.gameObject.GetComponent<DuckPoints>();
            duckPoints.horSpeed *= -1;
        }
    }
}