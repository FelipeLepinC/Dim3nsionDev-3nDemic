using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeEnergia : MonoBehaviour
{
    public Image barraDeEnergia;

    public float energiaActual;

    public float energiaMaxima;

    bool empujar = false;

    public GameObject PanelTiempo;
    private TimeControllerTortuga tiempo;

    Rigidbody playerRb;

    protected Transform atrapado = null;
    protected Vector3 difTrampaPlayer = Vector3.zero;

    private int estado;
    private int secondLock;

    //Sonidos

    private SoundManager soundManager;

    // Update is called once per frame

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
        estado = 0;
        secondLock = 0;
    }

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        barraDeEnergia.fillAmount = energiaActual / energiaMaxima;
        if (secondLock == 0){
            secondLock = 1;
            StartCoroutine(MostrarEstado());
        }
        if (Input.GetKeyDown("space")){
            estado += 1;
        }

    }
    void LateUpdate()
    {
        if (atrapado != null)
        {
            transform.position = atrapado.position - difTrampaPlayer;
        }
        if ((OVRInput.Get(OVRInput.Button.One) || Input.GetKey(KeyCode.E)) && atrapado != null)
        {
            if (energiaActual >= 10)
            {
                BajarEnergia(1);
                Liberado();
                Debug.Log("Liberado");
            }
        }
        if (OVRInput.Get(OVRInput.Button.One) && atrapado == null)
        {
            Empujar();
            Debug.Log("Modo Empujar");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Alimento")
        {
            AumentarEnergia();
            Destroy(collision.gameObject);
            soundManager.SeleccionAudio(0, 1.0f);
        }
        else if (collision.gameObject.tag == "NoAlimento")
        {
            BajarEnergia(1);
            Destroy(collision.gameObject);
            //soundManager.SeleccionAudio(1, 1.0f);
        }
        else if (collision.gameObject.tag == "TrampaNPC")
        {
            soundManager.SeleccionAudio(6, 1.0f);
            if (empujar)
            {
                BajarEnergia(1);
                Normal();
                Debug.Log("Volviendo al modo normal");
            }
            else
            {
                BajarEnergia(2);
            }
            if (energiaActual == 0) Debug.Log("No tienes energ�a para mover la trampa");
        }
        else if (collision.gameObject.tag == "TrampaPlayer")
        {
            Atrapado(collision.gameObject.transform);
            soundManager.SeleccionAudio(6, 1.0f);
            if (energiaActual < 10)
            {
                tiempo = PanelTiempo.GetComponent<TimeControllerTortuga>();
                tiempo.finished = true;
                Debug.Log("No tienes suficiente energ�a para liberarte");
            }
            Debug.Log("Quedaste Atrapado");
        }
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "TrampaNPC")
        {
            BajarEnergia(2);
            if (energiaActual == 0) Debug.Log("No tienes energía para mover la trampa");
        }
    }

    void BajarEnergia(int situacion)
    {
        soundManager.SeleccionAudio(1, 1.0f);
        if (situacion == 1) // me estoy liberando de una trampa player o me comi un no alimento
        {
            if (energiaActual - 10 >= 0) energiaActual = energiaActual - 10;
            else energiaActual = 0;
        }
        else if (situacion == 2) // estoy empujando una trampa
        {
            if (energiaActual - 0.5f >= 0) energiaActual = energiaActual - 0.1f;
            else energiaActual = 0;
        }
        if (energiaActual == 0) playerRb.mass = 1e-07f;
        barraDeEnergia.fillAmount = energiaActual / energiaMaxima;
    }

    void AumentarEnergia()
    {
        if (energiaActual + 10 < energiaMaxima)
        {
            if (energiaActual == 0) playerRb.mass = 1;
            energiaActual = energiaActual + 10;
        }
        else
        {
            energiaActual = energiaMaxima;
        }
        barraDeEnergia.fillAmount = energiaActual / energiaMaxima;
    }
    void Atrapado(Transform posicionTrampa)
    {
        CharacterController cc = GetComponent<CharacterController>();
        if (cc.enabled)
        {
            cc.enabled = false;
            if (atrapado == null || atrapado != posicionTrampa)
            {
                difTrampaPlayer = posicionTrampa.position - transform.position;
            }
            atrapado = posicionTrampa;
        }
    }
    public void Liberado()
    {
        Debug.Log("Me acabo de liberar");
        atrapado = null;
        CharacterController cc = GetComponent<CharacterController>();
        if (!cc.enabled)
        {
            cc.enabled = true;
        }
    }
    void Empujar()
    {
        empujar = true;
        playerRb.mass = 50;
    }
    void Normal()
    {
        empujar = false;
        playerRb.mass = 1;
    }

    IEnumerator MostrarEstado(){
        //Debug.Log("El estado del jugador es: " + estado);
        yield return new WaitForSeconds(2);
        secondLock = 0;
    }
}
