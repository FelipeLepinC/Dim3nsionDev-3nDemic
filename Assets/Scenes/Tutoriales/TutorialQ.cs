using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialQ : MonoBehaviour
{

    public float cooldown = 4.0f;
    public bool comprobarbienhecho = false;
    public float tiempobienhecho = 0.0f;
    public float pasos = 1.0f;
    public bool tocomanzana = false;
    public bool madri = false;
    public bool yaentro = false;
    public bool dejaque = false;
    public bool reune10 = false;
    public bool activa = false;
    public bool com = false;
    public float tiempocompletado = 0.0f;

    public GameObject bienhecho;
    public GameObject tocamanzana;
    public AppleCounter1 contador;
    public GameObject regresa;
    public GameObject cazador;
    public GameObject deja;
    public GameObject reune;
    public GameObject boost;
    public GameObject completado;
    

    // Update is called once per frame
    void Update()
    {
        if(contador.GetComponent<AppleCounter1>().counter >= 1){
            if(!tocomanzana){
                tocomanzana = true;
                tocamanzana.SetActive(false);
                bienhecho.SetActive(true);
                comprobarbienhecho = true;
            }
        }

        if(comprobarbienhecho){
            tiempobienhecho += Time.deltaTime;
            if(tiempobienhecho >= cooldown){
                comprobarbienhecho = false;
                bienhecho.SetActive(false);
                tiempobienhecho = 0.0f;
                if(pasos == 1){
                    madri = true;
                }
                if(pasos == 3){
                    dejaque = true;
                }
                if(pasos == 2){
                    reune10 = true;
                }
                if(pasos == 4){
                    activa = true;
                }
                if(pasos == 5){
                    com = true;
                }
            }
        }

        if(madri){
            regresa.SetActive(true);
            if(contador.GetComponent<AppleCounter1>().total >= 1){
                if(!yaentro){
                    yaentro = true;
                    madri = false;
                    regresa.SetActive(false);
                    bienhecho.SetActive(true);
                    comprobarbienhecho = true;
                    pasos += 1;
                }
            }
        }

        if(dejaque){
            deja.SetActive(true);
            cazador.SetActive(true);
            if(cazador.GetComponent<Cazador1>().trapped == true){
                dejaque = false;
                deja.SetActive(false);
                cazador.SetActive(false);
                bienhecho.SetActive(true);
                pasos += 1;
                comprobarbienhecho = true;
            }
        }

        if(reune10){
            reune.SetActive(true);
            if(contador.GetComponent<AppleCounter1>().counter >= 5){
                reune10 = false;
                reune.SetActive(false);
                bienhecho.SetActive(true);
                pasos += 1;
                comprobarbienhecho = true;
            }
        }

        if(activa){
            boost.SetActive(true);
            if(OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0){
                activa = false;
                boost.SetActive(false);
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
