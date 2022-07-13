using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogoScript : MonoBehaviour
{
    public void ChangeSortingLayer()
    {
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
    }

    public void RestSortingLayer()
    {
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 4;
    }
}