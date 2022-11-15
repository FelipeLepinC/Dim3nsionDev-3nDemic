using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    GameObject[] Paneles;
    TimeControllerRana ControlerReferencia;
    public bool tocoObstaculo = false;

    void Start()
    {
        Paneles = GameObject.FindGameObjectsWithTag("PanelTiempo");
        ControlerReferencia = Paneles[0].GetComponent<TimeControllerRana>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ControlerReferencia.cantTotalJugadores == ControlerReferencia.cantJugadoresColisionandoObstaculo)
        {
            // Mover obstaculo
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.mass = 1;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            for (int i = 0; i < ControlerReferencia.cantTotalJugadores; i++)
            {
                GameObject panel = Paneles[i];
                panel.GetComponent<TimeControllerRana>().JugadorColisionandoObstaculo();
                tocoObstaculo = true;
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
                panel.GetComponent<TimeControllerRana>().JugadorNoColisionandoObstaculo();
            }
        }
    }
}
