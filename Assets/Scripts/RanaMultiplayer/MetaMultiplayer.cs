using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MetaMultiplayer : MonoBehaviourPunCallbacks
{
    int cantidadJugadores;
    TimeControllerRana ControladorJuego;
    public GameObject[] jugadores;
    PhotonView view;
    public GameObject onePlayer;
    public TerminarRana terminaRana;

    public int cantidadJugadoresEnMeta;

    void Start()
    {
        cantidadJugadores = PhotonNetwork.CurrentRoom.PlayerCount;
        cantidadJugadoresEnMeta = 0;
        jugadores = GameObject.FindGameObjectsWithTag("Player");
        Debug.Log("Cantidad de jugadores : "+jugadores.Length);

        foreach (GameObject jugador in jugadores)
        {
            Debug.Log("Nombre del jugador : "+jugador.name);
            if(jugador.name == "RanaVR(Clone)")
            {
                view = jugador.GetComponent<PhotonView>();
                if(view.IsMine) onePlayer = jugador;
            }
        }
        terminaRana = onePlayer.GetComponent<TerminarRana>();
        // ControladorJuego = GameObject.Find("PanelTiempo").GetComponent<TimeControllerRana>();
    }

    void Update()
    {
        if (cantidadJugadores == 0 || cantidadJugadores == cantidadJugadoresEnMeta)
        {
            // ControladorJuego.finished = true;
            terminaRana.changeFinished();
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
