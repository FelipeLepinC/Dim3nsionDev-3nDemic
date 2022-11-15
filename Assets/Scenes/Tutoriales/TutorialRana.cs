using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public bool tococharco = false;
    public bool com = false;
    public Vector3 jugador;
    
    public GameObject bienhecho;
    public GameObject muevase;
    public GameObject saltar;
    public GameObject mosquito;
    public HealthRana rana;
    public GameObject moscas;
    public Obstaculo obs;
    public GameObject tocarObstaculo;
    public GameObject obstaculos;
    public Charco charquito;
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
            saltar.SetActive(true);
            if(Input.GetButtonDown("One")){
                contador += 1;
                if(contador >= 200){
                    ranasaltando = false;
                    saltar.SetActive(false);
                    bienhecho.SetActive(true);
                    pasos += 1;
                    comprobarbienhecho = true;
                }
            }
        }

        if(secomiomosquito){
            mosquito.SetActive(true);
            moscas.SetActive(true);
            if(rana.GetComponent<HealthRana>().secomiomosquito1){
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
            if(obs.GetComponent<Obstaculo>().tocoObstaculo){
                tocoObstaculo1 = false;
                tocarObstaculo.SetActive(false);
                bienhecho.SetActive(true);
                pasos += 1;
                comprobarbienhecho = true;
            }
        }

        if(tococharco){
            tocarCharco.SetActive(true);
            if(charquito.GetComponent<Charco>().esAlcanzado){
                tococharco = false;
                tocarCharco.SetActive(false);
                bienhecho.SetActive(true);
                pasos += 1;
                comprobarbienhecho = true;
            }
        }

        if(com){
            completado.SetActive(true);
        }
    }
}
