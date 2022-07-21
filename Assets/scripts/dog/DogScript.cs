using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogScript : MonoBehaviour
{
    public Vector3 originalPos;

    private void Start()
    {
        originalPos = gameObject.transform.parent.position;
    }

    public void WhereDog2Appear(Vector2 position)
    {
        transform.parent.position = new Vector2(position.x, -2.81f);
        gameObject.GetComponent<Animator>().SetTrigger("huntedDuck");
    }

    public void DogLaughing()
    {
        transform.parent.position = originalPos;
        gameObject.GetComponent<Animator>().SetTrigger("noHuntedDuck");
    }
}