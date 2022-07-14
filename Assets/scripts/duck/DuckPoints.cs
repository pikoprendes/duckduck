using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DuckPoints : MonoBehaviour
{
    public int duckPoints = 500;
    public Text puntuacionPato;

    public int ReturnDuckPoints()
    {
        return duckPoints;
    }
}