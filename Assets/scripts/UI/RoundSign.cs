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

    //public enum states
    //{
    //    canShoot,
    //    spawn,
    //    showScore
    //}

    //public states CurrentState = states.spawn;

    //private void Start()
    //{
    //}

    //private void Update()
    //{
    //    if (!manager.canManage)
    //    {
    //        duckSpawner.canISpawn = false;
    //        StartCoroutine(ShowRoundSign());
    //    }
    //}

    //public IEnumerator ShowRoundSign()
    //{
    //    playerShoot.canIShoot = false;
    //    duckSpawner.canISpawn = false;

    //    ShowChildren();

    //    float elapsedTime = 0;
    //    while (elapsedTime < timeShowingSign)
    //    {
    //        elapsedTime += Time.deltaTime;
    //        yield return null;
    //    }
    //    playerShoot.canIShoot = true;
    //    duckSpawner.canISpawn = true;
    //    manager.canManage = true;

    //    HideChildren();
    //}

    //public void HideChildren()
    //{
    //    for (int i = 0; i < gameObject.transform.childCount; i++)
    //    {
    //        gameObject.transform.GetChild(i).gameObject.SetActive(false);
    //    }
    //}

    //public void ShowChildren()
    //{
    //    for (int i = 0; i < gameObject.transform.childCount; i++)
    //    {
    //        gameObject.transform.GetChild(i).gameObject.SetActive(true);
    //    }
    //}
}