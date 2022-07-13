using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckFalling : MonoBehaviour
{
    [SerializeField] private float fallingSpeed = -6.5f;
    private bool isFalling = false;

    public void DeadFallingDuck() //se activa durante la animacion
    {
        transform.GetComponentInParent<MoveDuck>().verSpeed = fallingSpeed;
        gameObject.GetComponentInParent<Rigidbody2D>().simulated = false;
    }

    public void DeactivateDuck() //al finalizar la anmiacion de morir desactivamos en pato y le devolvemos la velocidad originial para cuando vuelva a spawnearse
    {
        MoveDuck moveduck = GetComponentInParent<MoveDuck>();
        moveduck.IsDuckInScene();
        gameObject.GetComponent<Animator>().SetBool("isDead", false);
        gameObject.GetComponentInParent<Rigidbody2D>().simulated = true;
        moveduck.horSpeed = moveduck.horSpeedSave;
        moveduck.verSpeed = moveduck.verSpeedSave;
        moveduck.DeactivateParent();
    }

    public IEnumerator FlipDeadDuckWhileFalling(Transform tranform)
    {
        while (isFalling)
        {
            transform.rotation = Quaternion.Euler(0, 5, 0);
            yield return new WaitForSeconds(0.1f);
        }
        isFalling = false;
    }

    public void FlipParent()
    {
        isFalling = true;
        Transform transform = GetComponentInParent<Transform>();
        StopAllCoroutines();
        StartCoroutine(FlipDeadDuckWhileFalling(transform));
    }
}