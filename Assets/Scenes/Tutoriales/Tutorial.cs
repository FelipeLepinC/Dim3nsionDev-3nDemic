using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{

    public float cooldown = 4.0f;
    public float caminando = 0.0f;
    public float tiempobienhecho = 0.0f;
    public bool semovio = false;
    public bool comprobarbienhecho = false;
    public bool disparar = false;
    public bool puma1 = false;
    public bool murio = false;
    public bool com = false;
    public float contador = 0.0f;
    public float pasos = 1.0f;
    public float tiempocompletado = 0.0f;
    public Vector3 jugador;

    public GameObject bienhecho;
    public GameObject muevase;
    public GameObject dispara;
    public GameObject portal;
    public GameObject puma;
    public GameObject completado;
    
    void Start(){
        jugador = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if(jugador != transform.position){
            caminando += Time.deltaTime;
            jugador = transform.position;
            if(!semovio && caminando >= 2.0f){
                semovio = true;
                muevase.SetActive(false);
                bienhecho.SetActive(true);
                comprobarbienhecho = true;
            }
        }

        if(comprobarbienhecho){
            tiempobienhecho += Time.deltaTime;
            if(tiempobienhecho >= cooldown){
                comprobarbienhecho = false;
                bienhecho.SetActive(false);
                if(pasos == 1){
                    disparar = true;
                }
                if(pasos == 2){
                    puma1 = true;
                }
                if(pasos == 3){
                    com = true;
                }
                tiempobienhecho = 0.0f;
            }
        }

        if(disparar){
            dispara.SetActive(true);
            if(Input.GetKey(KeyCode.E) || OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0){
                contador += 1;
                if(contador >= 200){
                    disparar = false;
                    dispara.SetActive(false);
                    bienhecho.SetActive(true);
                    pasos += 1;
                    comprobarbienhecho = true;
                }
            }
        }

        if(puma1){
            puma.SetActive(true);
            portal.SetActive(true);
            if(murio){
                puma1 = false;
                puma.SetActive(false);
                portal.SetActive(false);
                bienhecho.SetActive(true);
                pasos += 1;
                comprobarbienhecho = true;
            }
        }

        if(com){
            completado.SetActive(true);
            tiempocompletado += Time.deltaTime;
            if(tiempocompletado >= 5.0f){
                SceneManager.LoadScene("Museo VR");
            }
        }
    }
}
