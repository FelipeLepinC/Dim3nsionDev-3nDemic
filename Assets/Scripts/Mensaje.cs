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
            }
        }
    }

    private void LimpiarMensajeTecla(){
        SceneManager.LoadScene("Quirquincho VR");
    }

    private void Tortuguita(){
        SceneManager.LoadScene("JuegoTortuga VR");
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
