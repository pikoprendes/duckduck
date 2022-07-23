using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogScript : MonoBehaviour
{
    [SerializeField] private Vector3 originalPos;
    [SerializeField] private float timeBeforeDogAppears = 0.5f;
    [SerializeField] private AudioSource audioDogUp;
    [SerializeField] private AudioSource audioDogLaughing;

    private void Start()
    {
        originalPos = gameObject.transform.parent.position;
    }

    public void WhereDog2Appears(Vector2 position)
    {
        StartCoroutine(DogAppearsCor(position));
    }

    public void DogLaughing()
    {
        transform.parent.position = originalPos;
        gameObject.GetComponent<Animator>().SetTrigger("noHuntedDuck");
        audioDogLaughing.Play();
    }

    public IEnumerator DogAppearsCor(Vector2 position)
    {
        yield return new WaitForSeconds(timeBeforeDogAppears);
        transform.parent.position = new Vector2(position.x, -2.81f);
        gameObject.GetComponent<Animator>().SetTrigger("huntedDuck");
        audioDogUp.Play();
    }
}