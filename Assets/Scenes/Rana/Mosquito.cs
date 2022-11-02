using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mosquito : MonoBehaviour
{
    const float vidaAgregada = 10f;
    private float contTime;
    private float Temporalizador;
    private int reloj;
    private float speed;
    private float x;
    private float y;
    private float z;

    void Start()
    {
        //vidaAgregada = 10f;
        contTime = 0f;
        Temporalizador = 3f;
        reloj = 0;
        speed = 1f;
        x = 0f;
        y = 0f;
        z = 0f;
    }

    void Update()
    {
        contTime = contTime + (1f * Time.deltaTime);
        if (contTime > Temporalizador)
        {
            timming();
            contTime = 0f;
        }
        var step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, gameObject.transform.position + new Vector3(x, y, z), step);
    }

    void timming()
    {
        if (reloj == 0)//0,0,0
        {
            x = 1f;
            y = 1f;
            z = 1f;
        }
        else if (reloj == 1)//1,1,1
        {
            x = 0f;
            y = -1f;
            z = -1f;
        }
        else if (reloj == 2)//1,0,0
        {
            y = 1f;
        }
        else if (reloj == 3)//1,1,0
        {
            x = -1f;
            z = 1f;
        }
        else if (reloj == 4)//0,2,0
        {
            x = 1f;
            y = -1f;
        }
        else if (reloj == 5)//1,1,0
        {
            x = -1f;
        }
        else if (reloj == 6)//0,0,0
        {
            z = -1f;
        }
        else if (reloj == 7)//-1,-1,0
        {
            x = 1f;
            y = 1f;
        }
        else if (reloj == 8)//0,0,0
        {
            x = -1f;
        }
        else if (reloj == 9)//-1,1,0
        {
            y = -1f;
        }
        else if (reloj == 10)//-2,0,0
        {
            x = 1f;
            y = 1f;
            z = 0f;
        }
        else if (reloj == 11)//-1,1,0
        {
            x = -1f;
            y = -1f;
            z = 0f;
        }
        else if (reloj == 12)//-2,0,0
        {
            x = 1f;
            y = 1f;
            z = -1f;
        }
        else if (reloj == 13)//-1,1,0
        {
            z = 1f;
        }
        else if (reloj == 14)//0,0,0
        {
            y = 0f;
        }
        else if (reloj == 15)//1,0,0
        {
            x = -1f;
            reloj = -1;
        }
        reloj = reloj + 1;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Lengua")
        {
            HealthRana vidaPlayer = collision.gameObject.GetComponent<HealthRana>();
            vidaPlayer.GanarVida(vidaAgregada);
            Destroy(gameObject);
        }
    }
}