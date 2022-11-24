using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TerminarJuego : MonoBehaviour
{
    public float tiempoEsperaPantallaFinal = 10.0f;
    public float tiempoTranscurrido = 0f;
    public bool juegoTerminado = false;

    public GameObject jugador;

    public bool juegoQuirquincho;
    public bool juegoGuanaco;
    public bool juegoGuanacoArreglado;
    public bool juegoRana;
    public bool juegoRanaMultiplayer;
    public bool juegoTortuga;

    TimeController controllerQuirquicho;
    TimeControllerGuanaco controllerGuanaco;
    TimeControllerGuanaco1 controllerGuanaco1; // Juego del guanaco arreglado
    TimeControllerRana controllerRana;
    TimeControllerRanaMultiplayer controllerRanaMultiplayer;
    TimeControllerTortuga controllerTortuga;

    void Start()
    {
        juegoQuirquincho = gameObject.TryGetComponent(out controllerQuirquicho);
        if (!juegoQuirquincho)
        {
            juegoGuanaco = gameObject.TryGetComponent(out controllerGuanaco);
            if (!juegoGuanaco)
            {
                juegoGuanacoArreglado = gameObject.TryGetComponent(out controllerGuanaco1);
                if (!juegoGuanacoArreglado)
                {
                    juegoRana = gameObject.TryGetComponent(out controllerRana);
                    if (!juegoRana)
                    {
                        juegoRanaMultiplayer = gameObject.TryGetComponent(out controllerRanaMultiplayer);
                        if (!juegoRanaMultiplayer)
                        {
                            juegoTortuga = gameObject.TryGetComponent(out controllerTortuga);
                            if (!juegoTortuga)
                            {
                                Debug.Log("Ha habido un error en encontrar el juego");
                            }
                        }
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!juegoTerminado)
        {
            if (juegoQuirquincho)
            {
                juegoTerminado = controllerQuirquicho.finished;
            }
            else if (juegoGuanaco)
            {
                juegoTerminado = controllerGuanaco.finished;
            }
            else if (juegoGuanacoArreglado)
            {
                juegoTerminado = controllerGuanaco1.finished;
            }
            else if (juegoRana)
            {
                juegoTerminado = controllerRana.finished;
            }
            else if (juegoRanaMultiplayer)
            {
                juegoTerminado = controllerRanaMultiplayer.finished;
            }
            else if (juegoTortuga)
            {
                juegoTerminado = controllerTortuga.finished;
            }
        }
        else
        {
            tiempoTranscurrido += Time.deltaTime;
            if (tiempoTranscurrido > tiempoEsperaPantallaFinal)
            {
                // lógica de salida a escenario
                if (jugador.TryGetComponent(out Photon.Pun.PhotonView photon))
                {
                    // logica de abandono de sala
                }
                SceneManager.LoadScene("Museo VR");
            }
        }
    }
}
