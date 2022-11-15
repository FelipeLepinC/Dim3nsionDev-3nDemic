using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoMultiplayer : MonoBehaviour
{
    GameObject[] Paneles;
    TimeControllerRanaMultiplayer ControlerReferencia;

    void Start()
    {
        Paneles = GameObject.FindGameObjectsWithTag("PanelTiempo");
        ControlerReferencia = Paneles[0].GetComponent<TimeControllerRanaMultiplayer>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (ControlerReferencia.cantTotalJugadores == ControlerReferencia.cantJugadoresColisionandoObstaculo)
        // {
        //     // Mover obstaculo
        //     Rigidbody rb = GetComponent<Rigidbody>();
        //     rb.mass = 1;
        // }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            for (int i = 0; i < ControlerReferencia.cantTotalJugadores; i++)
            {
                GameObject panel = Paneles[i];
                panel.GetComponent<TimeControllerRanaMultiplayer>().JugadorColisionandoObstaculo();
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            for (int i = 0; i < ControlerReferencia.cantTotalJugadores; i++)
            {
                GameObject panel = Paneles[i];
                panel.GetComponent<TimeControllerRanaMultiplayer>().JugadorNoColisionandoObstaculo();
            }
        }
    }
}
