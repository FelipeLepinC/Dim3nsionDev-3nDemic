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
                    SceneManager.LoadScene("Quirquincho VR Tutorial");
                }
                if(juego == "Tortuga"){
                    SceneManager.LoadScene("JuegoTortuga VR Tutorial");
                }
                if(juego == "Rana"){
                    SceneManager.LoadScene("JuegoRanaVR Tutorial");
                }
                if(juego == "Guanaco"){
                    SceneManager.LoadScene("JuegoGuanaco VR Tutorial");
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
