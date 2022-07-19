using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimiteDownScript : MonoBehaviour
{
    public LayerMask playerMask;
    public DuckSpawner duckSpawner;
    private bool positionCollider;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Utils.IsInLayerMask(collision.gameObject, playerMask))
        {
            MoveDuck moveDuck = collision.gameObject.GetComponent<MoveDuck>();
            moveDuck.verSpeed *= -1;
        }
        Physics2D.IgnoreLayerCollision(0, 7, true);
    }

    private void Update()
    {
        if (duckSpawner.duckInScene) //si hay un pato en la escena sube el collider
        {
            gameObject.GetComponent<Animator>().SetBool("colliderUp", true);
        }
        else //si no hay un pato en la escen y tiene que spawnearse baja el collider para no intereferir con la spwan position
        {
            gameObject.GetComponent<Animator>().SetBool("colliderUp", false);
        }
    }

    public void ActivateCollider()
    {
        gameObject.GetComponent<Collider2D>().enabled = true;
    }

    public void DeactivateCollider()
    {
        gameObject.GetComponent<Collider2D>().enabled = false;
    }
}