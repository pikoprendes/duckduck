using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Camera myCamera;
    public int balasSet = 2; //por si más tarde queremos cambiar el numero de balas del que dispone el jugador
    public int balas;
    public Transform[] balasSprites;
    public Manager managerPartida;
    public bool canIShoot = false;

    private void Start()
    {
        BalasReset();
        canIShoot = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && canIShoot) //si apriento el boton izquiero del raton y puedo disparar
        {
            if (balas > 0)//si me quedan balas significa que aun puedo disparar
            {
                balas--;
                HideSpriteBala(balas); //ocultamos un sprite de bala
                shoot();
            }
            else //de lo contrario no me quedan balas y ya no podré abatir al pato
            {
                //pasar de ronda fly away en el manager que sube contador hit
                //LA SIGUIENTE FUNCION DEBE SER TEMPORAL HASTA IMPLEMENTAR ANIMACION DE IRSE
                DuckEraser();//desactivamos el pato activo en la escena
                managerPartida.MissedTarget(); //le comunicamos al manager que hemos fallado los tres disparos
                BalasSpritesActiveAll(balasSet); //volvemos a mostrar todos los sprites de las balas
                BalasReset(); //reseteamos las balas que tiene disponible el jugador
                canIShoot = false;
            }
        }
    }

    //private void OnMouseDown()
    //{
    //}

    public void shoot()
    {
        Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);
        //Debug.DrawRay(ray.origin, ray.direction * 20, Color.green);

        RaycastHit2D hit = Physics2D.Raycast(ray.origin, Vector2.right, 10f, LayerMask.GetMask("duck"));

        if (hit.collider != null) //si el disparo impacta en un pato (layer duck)
        {
            hit.collider.gameObject.GetComponent<MoveDuck>().DeadDuck();
            managerPartida.TargetHit(); //le comunicamos al manager que hemos abatido al pato
            DuckPoints DuckPoints = hit.collider.gameObject.GetComponent<DuckPoints>();
            managerPartida.score += DuckPoints.ReturnDuckPoints(); //sumamos a nuestra puntuacion los puntos que da ese pato
            BalasReset(); //reseteamos las balas que tiene disponible el jugador
            BalasSpritesActiveAll(balasSet); //reseteamos los sprites de las balas
            canIShoot = false;
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

    public void DuckEraser() //TEMPORAL //metodo que borra el pato de la escena si se agotan la balas sin haberlo abatido
    {
        MoveDuck moveduck = FindObjectOfType<MoveDuck>();
        moveduck.transform.gameObject.SetActive(false); //desactivamos el pato que no hemos abatido
        DuckSpawner duckSpawner = FindObjectOfType<DuckSpawner>();
        duckSpawner.duckInScene = false; //le comunicamos al duck spawner que puede lanzar otro pato
    }

    public void BalasReset()
    {
        balas = balasSet;
    }
}