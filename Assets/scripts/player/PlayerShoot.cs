using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Camera myCamera;
    public int balas = 3;
    public Manager managerPartida;
    
    void Start()
    {
        balas = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (balas > 0)
            {
                balas--;
                shoot();
            }
            else
            {
                managerPartida.MissedTarget();
                balas = 3;
                //pasar de ronda fly away en el manager que sube contador hit
            }
        }
        
    }

    public void shoot()
    {
        Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);
        //Debug.DrawRay(ray.origin, ray.direction * 20, Color.green);

        RaycastHit2D hit = Physics2D.Raycast(ray.origin, Vector2.right, 10f, LayerMask.GetMask("duck"));

        if (hit.collider != null)
        {
            hit.collider.gameObject.SetActive(false);
            DuckSpawner duckSpawner = FindObjectOfType<DuckSpawner>();
            duckSpawner.duckInScene = false;
            managerPartida.hit++;
            managerPartida.contadorHit++;
            managerPartida.score += 500; //cuando haya diferentes patos cada uno tendra un valor diferente en puntos. Acceder aqui 
            balas = 3;
        }


    }
}
