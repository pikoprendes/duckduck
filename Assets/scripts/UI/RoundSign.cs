using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundSign : MonoBehaviour
{
    public PlayerShoot playerShoot;
    public DuckSpawner duckSpawner;
    public Manager manager;
    public float timeShowingSign = 3;

    private void Update()
    {
        if (manager.changeRound)
        {
            manager.changeRound = false;
            StartCoroutine(ShowRoundSign());
        }
    }

    public IEnumerator ShowRoundSign()
    {
        playerShoot.canIShoot = false;
        duckSpawner.canISpawn = false;
        ShowChildren();

        yield return new WaitForSeconds(timeShowingSign);
        playerShoot.canIShoot = true;
        duckSpawner.canISpawn = true;
        manager.changeRound = false;

        HideChildren();
    }

    public void HideChildren()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void ShowChildren()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}