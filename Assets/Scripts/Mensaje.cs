using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mensaje : MonoBehaviour
{

    public string mensaje;
    public string juego;
    public bool entro = false;
    public AudioSource audiol;
    public bool estadoMensaje;
    [SerializeField] private GameObject iniciar;

    void Start(){
        estadoMensaje = false;
    }
    
    void OnGUI(){
        if (entro && estadoMensaje){
            iniciar.SetActive(true);
        }else{
            iniciar.SetActive(false);
        }

        if(estadoMensaje && mensaje == "Presiona E para jugar"){
            if (OVRInput.Get(OVRInput.Button.One))
            {
                if(juego == "Quirquincho"){
                    audiol.Play();
                    LimpiarMensajeTecla();
                }
                if(juego == "Tortuga"){
                    audiol.Play();
                    Tortuguita();
                }
                if(juego == "Rana"){
                    RanaJuego();
                }
                if(juego == "Guanaco"){
                    SceneManager.LoadScene("Carga Guanaco");
                }
            }

            if(OVRInput.Get(OVRInput.Button.Two)){
                if(juego == "Quirquincho"){
                    SceneManager.LoadScene("CargaQuirquincho 1");
                }
                if(juego == "Tortuga"){
                    SceneManager.LoadScene("CargaTortuga 1");
                }
                if(juego == "Rana"){
                    SceneManager.LoadScene("CargaRana 1");
                }
                if(juego == "Guanaco"){
                    SceneManager.LoadScene("Carga Guanaco 1");
                }
            }

            if(OVRInput.Get(OVRInput.Button.Three)){
                if(juego == "Quirquincho"){
                    SceneManager.LoadScene("LobbyQuirquinchoVR");
                }
                if(juego == "Tortuga"){
                    SceneManager.LoadScene("TortugaLobbyVR");
                }
                if(juego == "Rana"){
                    SceneManager.LoadScene("RanaLobbyVR");
                }
                if(juego == "Guanaco"){
                    SceneManager.LoadScene("GuanacoLobbyVR");
                }
            }
        }
    }

    private void LimpiarMensajeTecla(){
        SceneManager.LoadScene("CargaQuirquincho");
    }

    private void Tortuguita(){
        SceneManager.LoadScene("CargaTortuga");
    }

    private void RanaJuego(){
        SceneManager.LoadScene("CargaRana");
    }

    private void OnTriggerEnter(Collider other){
        entro = true;
        estadoMensaje = true;
    }

    private void OnTriggerExit(Collider other){
        entro = false;
        estadoMensaje = false;
    }
}
