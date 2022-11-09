using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meta : MonoBehaviour
{
    int cantidadJugadores;
    TimeControllerRana ControladorJuego;

    public int cantidadJugadoresEnMeta;

    void Start()
    {
        cantidadJugadores = GameObject.Find("Jugadores").transform.childCount;
        cantidadJugadoresEnMeta = 0;
        ControladorJuego = GameObject.Find("PanelTiempo").GetComponent<TimeControllerRana>();
    }

    void Update()
    {
        if (cantidadJugadores == 0 || cantidadJugadores == cantidadJugadoresEnMeta)
        {
            ControladorJuego.finished = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null && collision.gameObject.tag == "Player")
        {
            cantidadJugadoresEnMeta++;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision != null && collision.gameObject.tag == "Player")
        {
            cantidadJugadoresEnMeta--;
        }
    }
}
