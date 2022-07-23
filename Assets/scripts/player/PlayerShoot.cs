using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Camera myCamera;
    public int balasSet = 2; //por si más tarde queremos cambiar el numero de balas del que dispone el jugador
    public int balas;
    [SerializeField] private Transform[] balasSprites;
    [SerializeField] private Manager managerPartida;
    public bool canIShoot = false;
    [SerializeField] private float timeToShoot = 5f; //tiempo del que dispone el jugador para disparar
    [SerializeField] private AudioSource shootSound;

    private void Start()
    {
        shootSound = gameObject.GetComponent<AudioSource>();
        BalasReset();
        canIShoot = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (balas > 0)
        {
            if (Input.GetButtonDown("Fire1") && canIShoot)
            {
                balas--;
                HideSpriteBala(balas); //ocultamos un sprite de bala
                shootSound.Play();
                shoot();
            }
        }
        else
        {
            DuckEraser();//el pato se escapa
            managerPartida.MissedTarget(); //le comunicamos al manager que hemos fallado los tres disparos
            BalasSpritesActiveAll(balasSet); //volvemos a mostrar todos los sprites de las balas
            BalasReset(); //reseteamos las balas que tiene disponible el jugador
        }
    }

    //private void OnMouseDown()
    //{
    //}

    public void shoot()
    {
        Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 20, Color.green);


        RaycastHit2D hit = Physics2D.Raycast(ray.origin, Vector2.zero, 10f, LayerMask.GetMask("duck"));

        if (hit.collider != null) //si el disparo impacta en un pato (layer duck)
        {
            DuckPoints duckPoints = hit.collider.gameObject.GetComponent<DuckPoints>();
            duckPoints.health--;
            CheckDuckHealth(duckPoints);
        }
    }

    public void HideSpriteBala(int balas) //desactiva un sprite de bala cada disparo
    {
        balasSprites[balas].gameObject.SetActive(false);
    }

    public void BalasSpritesActiveAll(int balas) //vuelve a activar todos los sprites de las balas depues de cada pato
    {
        for (int i = 0; i < balasSprites.Length; i++)
        {
            balasSprites[i].gameObject.SetActive(true);
        }
    }

    public void DuckEraser() //si no matamos al pato o pasan mas de 5 segundos:
    {
        canIShoot = false;
        DuckPoints duckPoints = FindObjectOfType<DuckPoints>();
        duckPoints.DuckFlyingAway();
        DuckSpawner duckSpawner = FindObjectOfType<DuckSpawner>();
        duckSpawner.duckInScene = false; //le comunicamos al duck spawner que puede lanzar otro pato
        StopAllCoroutines();
    }

    public void BalasReset()
    {
        balas = balasSet;
    }

    public IEnumerator TimeCounter()
    {
        yield return new WaitForSeconds(timeToShoot);
        DuckEraser();
        managerPartida.MissedTarget(); //le comunicamos al manager que hemos fallado los tres disparos
        BalasSpritesActiveAll(balasSet); //volvemos a mostrar todos los sprites de las balas
        BalasReset(); //reseteamos las balas que tiene disponible el jugador
    }

    public void TimeCounterFunction()
    {
        StartCoroutine(TimeCounter());
    }

    public void StopAllCoroutineFunction()
    {
        StopAllCoroutines();
    }

    public void CheckDuckHealth (DuckPoints duckPoints)
    {
        if(duckPoints.health <= 0)
        {
            managerPartida.TargetHit(); //le comunicamos al manager que hemos abatido al pato
            managerPartida.score += duckPoints.ReturnDuckPoints(); //sumamos a nuestra puntuacion los puntos que da ese pato
            duckPoints.DeadDuck();
            BalasReset(); //reseteamos las balas que tiene disponible el jugador
            BalasSpritesActiveAll(balasSet); //reseteamos los sprites de las balas
            canIShoot = false;
            StopAllCoroutines();
        }

    }
}