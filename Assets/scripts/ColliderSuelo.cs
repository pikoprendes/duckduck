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
            MoveDuck moveDuck = collision.gameObject.GetComponent<MoveDuck>();
            moveDuck.DeactivateDuck();
            DogScript dog2 = FindObjectOfType<DogScript>();
            dog2.WhereDog2Appear(collision.contacts[0].point); //devuelve el punto de la colision, que es donde aparecera el perro con el pato
        }
    }
}