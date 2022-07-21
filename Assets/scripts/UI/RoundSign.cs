using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundSign : MonoBehaviour
{
    public PlayerShoot playerShoot;
    public DuckSpawner duckSpawner;
    public Manager manager;
    public float timeShowingSign = 7;
    public Animator dog1;

    private void Update()
    {
        if (manager.changeRound) //al cambiar de ronda
        {
            StopAllCoroutines();
            manager.changeRound = false;
            StartCoroutine(ShowRoundSign());
        }
    }

    public IEnumerator ShowRoundSign()
    {
        playerShoot.canIShoot = false; //le comunicamos al jugador que no puede disparar
        duckSpawner.canISpawn = false;//le comunicamos al spawner que no puede spawnear
        ShowChildren();
        dog1.transform.gameObject.SetActive(true);
        yield return new WaitForSeconds(timeShowingSign);
        dog1.transform.gameObject.SetActive(false);
        //una vez transcurrido x segundos ya puede comenzar la partida
        playerShoot.canIShoot = true;
        duckSpawner.canISpawn = true;

        HideChildren();
    }

    public void HideChildren() //oculta el panel que muestra la ronda en la que estamos
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void ShowChildren() //muestra el panel de la ronda en la que estamos
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}