using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimiteDownScript : MonoBehaviour
{
    public LayerMask playerMask;
    public DuckSpawner duckSpawner;
    private bool positionCollider;
    private float timeToActivateCollider = 1f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Physics2D.IgnoreLayerCollision(0, 7, true);
        if (Utils.IsInLayerMask(collision.gameObject, playerMask))
        {
            MoveDuck moveDuck = collision.gameObject.GetComponent<MoveDuck>();
            moveDuck.verSpeed *= -1;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //Debug.Log("First point that collided: " + collision.GetContact(1));
        //MoveDuck moveduck = collision.gameObject.GetComponent<MoveDuck>();
        //moveduck.DeactivateDuck();
    }

    private void Update()
    {
        if (duckSpawner.duckInScene) //si hay un pato en la escena sube el collider
        {
            //gameObject.GetComponent<Animator>().SetBool("colliderUp", true);
            StartCoroutine(ActivateColliderCor());
        }
        else //si no hay un pato en la escena y tiene que spawnearse baja el collider para no intereferir con la spwan position
        {
            //gameObject.GetComponent<Animator>().SetBool("colliderUp", false);
            DeactivateCollider();
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

    public IEnumerator ActivateColliderCor()
    {
        yield return new WaitForSeconds(timeToActivateCollider);
        ActivateCollider();
    }
}