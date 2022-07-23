using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    [SerializeField] public int ronda;
    [SerializeField] public int rondaSet = 1;
    [SerializeField] public int score;
    [SerializeField] public int scoreSet = 0;
    [SerializeField] public int duckCounter; //contador patos
    [SerializeField] public int duckCounterSet = 0;
    [SerializeField] public int hit; //cuenta los patos que se han abatido
    [SerializeField] public int hitSet = 0;
    [SerializeField] private Transform[] redDucks;
    [SerializeField] private Transform[] whiteDucks;
    private PlayerShoot player;
    private DuckSpawner duckSpawner;
    private RoundSign roundSign;
    [SerializeField] private float timeBetweenRounds = 7;
    [SerializeField] private float timeBeforeShowingDog = 5;
    [SerializeField] private Animator dog1;
    public bool isDuck10 = false;

    private void Start()
    {
        ronda = rondaSet;
        score = scoreSet;
        hit = hitSet;
        duckCounter = duckCounterSet;
        player = FindObjectOfType<PlayerShoot>();
        duckSpawner = FindObjectOfType<DuckSpawner>();
        roundSign = FindObjectOfType<RoundSign>();
        StartCoroutine(ChangeRound());
    }

    private void Update()
    {
        if (duckCounter == 10)
        {
            isDuck10 = true;
            duckCounter = duckCounterSet;
            NextRound();
        }
    }

    public void MissedTarget()
    {
        duckCounter++; //no hemoss abatido el pato pero sube el contador de patos
    }

    public void TargetHit()
    {
        ShowRedDuck(duckCounter);//mostramos el pato rojo en señal que lo hemos alcanzado
        hit++; //hemos abatido al pato
        duckCounter++; //un pato mas
    }

    public void NextRound() //metodo que introduce el cambio de ronda
    {
        if (ronda == 10)
        {
            PlayerPrefs.SetInt("Score", score);
            StartCoroutine(ChangeScene());
            
        }
        duckSpawner.canISpawn = false; //le comunicamos al spawner que no puede spawnear
        player.canIShoot = false; //le comunicamos al jugador que no puede disparar
        StartCoroutine(ChangeRound()); //corrutina que muestra el cartel y el perro
        StartCoroutine(NewRound());//funcion que resetea los sprites de los patos y el contador
        //NewRound(); //funcion que resetea los sprites de los patos y el contador
    }

    public void ShowRedDuck(int contadorHit) //muestra el pato rojo si hemos alcanzado al pato en el lugar que corresponde
    {
        redDucks[contadorHit].gameObject.SetActive(true);
    }

    public void ResetRedDucks() //oculta todos los patos rojos al acabar cada ronda
    {
        for (int i = 0; i < redDucks.Length; i++)
        {
            redDucks[i].gameObject.SetActive(false);
        }
    }


    public void ActivateBlinkinRedDucks() //metodo para final de ronda que hace parpadear los sprites rojos del pato
    {
        for (int i = 0; i < hit; i++)
        {
            redDucks[i].gameObject.SetActive(true);
        }
    }


    public IEnumerator NewRound()
    {
        ResetRedDucks();
        ActivateBlinkinRedDucks();
        yield return new WaitForSeconds(3);
        hit = hitSet;
        ronda++;
    }
    public IEnumerator ChangeRound() //rutina que muestra al perro y el cartel de ronda
    {
        yield return new WaitForSeconds(timeBeforeShowingDog);
        gameObject.GetComponent<AudioSource>().Play();
        roundSign.ShowChildren();
        dog1.transform.gameObject.SetActive(true);
        yield return new WaitForSeconds(timeBetweenRounds);
        ResetRedDucks();
        dog1.transform.gameObject.SetActive(false);
        player.canIShoot = true;
        duckSpawner.canISpawn = true;
        roundSign.HideChildren();
        isDuck10 = false;
    }

    public IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(2);
    }

}