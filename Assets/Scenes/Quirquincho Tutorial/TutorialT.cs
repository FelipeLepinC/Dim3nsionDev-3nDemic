using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialT : MonoBehaviour
{

    public float cooldown = 4.0f;
    public bool comprobarbienhecho = false;
    public float tiempobienhecho = 0.0f;
    public float moviendose = 0.0f;
    public bool semovio = false;
    public float pasos = 1.0f;
    public bool alimento = false;
    public bool secomio = false;
    public bool basura = false;
    public bool secomiobasura = false;
    public bool liberartortugas = false;
    public bool estareatrapado = false;
    public bool estoyatrapado = false;
    public bool deboliberarme = false;
    public bool com = false;
    
    public GameObject moverse;
    public Vector3 jugador;
    public GameObject bienhecho;
    public GameObject consumiendoalimento;
    public GameObject consumiendobasura;
    public GameObject energia;
    public GameObject liberar;
    public GameObject trampas;
    public GameObject tortuguitas;
    public ContadorTortugas contador;
    public GameObject quedaratrapado;
    public GameObject atrapado;
    public GameObject liberarsede;
    public GameObject completado;

    void Start(){
        jugador = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(jugador != transform.position){
            moviendose += Time.deltaTime;
            jugador = transform.position;
            if(!semovio && moviendose >= 4.0f){
                semovio = true;
                moverse.SetActive(false);
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
                    alimento = true;
                }
                if(pasos == 2){
                    basura = true;
                }
                if(pasos == 3){
                    liberartortugas = true;
                }
                if(pasos == 4){
                    estareatrapado = true;
                }
                if(pasos == 5){
                    com = true;
                }
                tiempobienhecho = 0.0f;
            }
        }

        if(alimento){
            consumiendoalimento.SetActive(true);
            energia.SetActive(true);
            if(secomio){
                alimento = false;
                consumiendoalimento.SetActive(false);
                bienhecho.SetActive(true);
                pasos += 1;
                comprobarbienhecho = true;
            }
        }

        if(basura){
            consumiendobasura.SetActive(true);
            if(secomiobasura){
                basura = false;
                consumiendobasura.SetActive(false);
                energia.SetActive(false);
                bienhecho.SetActive(true);
                pasos += 1;
                comprobarbienhecho = true;
            }
        }

        if(liberartortugas){
            liberar.SetActive(true);
            tortuguitas.SetActive(true);
            trampas.SetActive(true);
            if(contador.rescatadas > 0){
                liberartortugas = false;
                liberar.SetActive(false);
                tortuguitas.SetActive(false);
                trampas.SetActive(false);
                bienhecho.SetActive(true);
                pasos += 1;
                comprobarbienhecho = true;
            }
        }

        if(estareatrapado){
            quedaratrapado.SetActive(true);
            atrapado.SetActive(true);
            if(estoyatrapado){
                estareatrapado = false;
                quedaratrapado.SetActive(false);
                deboliberarme = true;
            }
        }

        if(deboliberarme){
            liberarsede.SetActive(true);
            if((OVRInput.Get(OVRInput.Button.One) || Input.GetKey(KeyCode.E))){
                deboliberarme = false;
                liberarsede.SetActive(false);
                atrapado.SetActive(false);
                bienhecho.SetActive(true);
                pasos += 1;
                comprobarbienhecho = true;
            }
        }

        if(com){
            completado.SetActive(true);
        }
    }

    void OnCollisionEnter(Collision collision){
        if(alimento){
            if (collision.gameObject.tag == "Alimento")
            {
                secomio = true;
            }
        }
        if(basura){
            if (collision.gameObject.tag == "NoAlimento")
            {
                secomiobasura = true;
            }
        }
        else if (collision.gameObject.tag == "TrampaPlayer")
        {
            estoyatrapado = true;
        }
    }
}
