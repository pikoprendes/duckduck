using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimiteTopScript : MonoBehaviour
{
    [SerializeField] private LayerMask duckMask;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Utils.IsInLayerMask(collision.gameObject, duckMask))
        {
            DuckPoints duckPoints = collision.gameObject.GetComponent<DuckPoints>();
            duckPoints.verSpeed *= -1;
        }
        Physics2D.IgnoreLayerCollision(0, 8, true);
    }
}