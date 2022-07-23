using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderSuelo : MonoBehaviour
{
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private AudioSource duckGround;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Utils.IsInLayerMask(collision.gameObject, playerMask))
        {
            DuckPoints duckPoints = collision.gameObject.GetComponent<DuckPoints>();
            duckGround.Play();
            duckPoints.DeactivateDuck();
            DogScript dog2 = FindObjectOfType<DogScript>();
            dog2.WhereDog2Appears(collision.contacts[0].point); //devuelve el punto de la colision, que es donde aparecera el perro con el pato
        }
    }
}