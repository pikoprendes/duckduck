using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Camera myCamera;
    public int balasSet = 3; //por si más tarde queremos cambiar el numero de balas del que dispone el jugador
    public int balas;
    public Transform[] balasSprites;
    public Manager managerPartida;
    public bool canIShoot = false;

    private void Start()
    {
        balas = balasSet;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (balas > 0)
            {
                balas--;
                BalasSpritesHide(balas); //ocultamos un sprite de bala
                shoot();
            }
            else
            {
                managerPartida.MissedTarget(); //le comunicamos al manager que hemos fallado los tres disparos
                BalasSpritesActiveAll(balasSet); //volvemos a mostrar todas las balas
                balas = balasSet; //reseteamos las balas que tiene disponible el jugador
                //pasar de ronda fly away en el manager que sube contador hit
            }
        }
    }

    public void shoot()
    {
        Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);
        //Debug.DrawRay(ray.origin, ray.direction * 20, Color.green);

        RaycastHit2D hit = Physics2D.Raycast(ray.origin, Vector2.right, 10f, LayerMask.GetMask("duck"));

        if (hit.collider != null) //si el disparo impacta en un pato (layer duck)
        {
            hit.collider.gameObject.SetActive(false); //apagamos el pato
            DuckSpawner duckSpawner = FindObjectOfType<DuckSpawner>();
            duckSpawner.duckInScene = false; //le decimos al duckSpawner que lance otro pato
            managerPartida.ShowRedDuck(managerPartida.duckCounter);//mostramos el pato rojo en señal que lo hemos alcanzado
            managerPartida.hit++; //hemos abatido al pato
            managerPartida.duckCounter++; //un pato mas
            DuckPoints DuckPoints = hit.collider.gameObject.GetComponent<DuckPoints>();
            managerPartida.score += DuckPoints.duckPoints; //sumamos a nuestra puntuacion los puntos que da ese pato
            balas = balasSet; //reseteamos las balas que tiene disponible el jugador
            BalasSpritesActiveAll(balasSet); //reseteamos los sprites de las balas
        }
    }

    public void BalasSpritesHide(int balas) //desactiva un sprite de bala cada disparo
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
}