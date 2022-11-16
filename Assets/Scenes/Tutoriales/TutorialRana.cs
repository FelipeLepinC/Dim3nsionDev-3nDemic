using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;

public class TutorialRana : MonoBehaviour
{

    public float cooldown = 4.0f;
    public bool comprobarbienhecho = false;
    public float tiempobienhecho = 0.0f;
    public float pasos = 1.0f;
    public float caminando = 0.0f;
    public bool semovio = false;
    public bool ranasaltando = false;
    public float contador = 0.0f;
    public bool secomiomosquito = false;
    public bool tocoObstaculo1 = false;
    public bool tocoObstaculo = false;
    public bool tococharco = false;
    public bool com = false;
    public bool esAlcanzado = false;
    public bool secomiomosquito1 = false;
    public float tiempocompletado = 0.0f;
    public Vector3 jugador;
    
    bool estadoBotonApretado; 
    public GameObject bienhecho;
    public GameObject muevase;
    public GameObject saltar;
    public GameObject mosquito;
    public HealthRana rana;
    public GameObject moscas;
    public GameObject tocarObstaculo;
    public GameObject obstaculos;
    public GameObject tocarCharco;
    public GameObject completado;
    

    // Start is called before the first frame update
    void Start()
    {
        jugador = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(jugador != transform.position){
            caminando += Time.deltaTime;
            jugador = transform.position;
            if(!semovio && caminando >= 5.0f){
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
                    ranasaltando = true;
                } else if(pasos == 2){
                    secomiomosquito = true;
                } else if(pasos == 3){
                    tocoObstaculo1 = true;
                } else if(pasos == 4){
                    tococharco = true;
                } else if(pasos == 5){
                    com = true;
                }
                tiempobienhecho = 0.0f;
            }
        }

        if(ranasaltando){
            estadoBotonApretado = gameObject.GetComponent<ContinuousMovement>().primaryButtonState;
            saltar.SetActive(true);
            if((estadoBotonApretado || Input.GetKey(KeyCode.E))){
                ranasaltando = false;
                saltar.SetActive(false);
                bienhecho.SetActive(true);
                pasos += 1;
                comprobarbienhecho = true;
            }
        }

        if(secomiomosquito){
            mosquito.SetActive(true);
            moscas.SetActive(true);
            if(secomiomosquito1){
                secomiomosquito = false;
                mosquito.SetActive(false);
                bienhecho.SetActive(true);
                pasos += 1;
                comprobarbienhecho = true;
            }
        }

        if(tocoObstaculo1){
            tocarObstaculo.SetActive(true);
            obstaculos.SetActive(true);
            if(tocoObstaculo){
                tocoObstaculo1 = false;
                tocarObstaculo.SetActive(false);
                bienhecho.SetActive(true);
                pasos += 1;
                comprobarbienhecho = true;
            }
        }

        if(tococharco){
            tocarCharco.SetActive(true);
            if(esAlcanzado){
                tococharco = false;
                tocarCharco.SetActive(false);
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

    void OnCollisionEnter(Collision collision){
        if(tocoObstaculo1){
            if (collision.gameObject.tag == "obsta")
            {
                tocoObstaculo = true;
            }
        }
        if(tococharco){
            if (collision.gameObject.tag == "charco")
            {
                esAlcanzado = true;
            }
        }

        if(secomiomosquito){
            if (collision.gameObject.tag == "mosca")
            {
                secomiomosquito1 = true;
            }
        }
    }
}
