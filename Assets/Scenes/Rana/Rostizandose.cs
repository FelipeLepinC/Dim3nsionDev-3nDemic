using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rostizandose : MonoBehaviour
{
    GameObject alerta;
    HealthRana vida;
    // Start is called before the first frame update
    //Sonidos
    private SoundManager soundManager;
    float duracionSonidoRostizando = 3.0f;
    float tiempoSonando = 0.0f;
    bool sonarRostizar = false;
    void Start()
    {
        vida = GetComponent<HealthRana>();
        alerta = GameObject.Find("alert");
        alerta.SetActive(false);
        soundManager = FindObjectOfType<SoundManager>();
    }

    private void Update()
    {
        if (sonarRostizar)
        {
            soundManager.SeleccionAudio(3, 0.3f);
            sonarRostizar = false;
        }
    }

    // Update is called once per frame
    private void OnCollisionStay(Collision collision)
    {
        string tag = collision.gameObject.tag;
        if (tag == "Terrain") // Si no est� pisando agua o est� en la meta
        {
            vida.RecibirDano(0.5f);
            alerta.SetActive(true);
            tiempoSonando += Time.deltaTime;
            if (tiempoSonando > duracionSonidoRostizando)
            {
                sonarRostizar = true;
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag != "Agua") // Si no est� pisando agua
        {
            alerta.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Agua")
        {
            soundManager.SeleccionAudio(1, 1.0f);
        }
        else if (collision.gameObject.tag == "Terrain")
        {
            sonarRostizar = true;
            tiempoSonando = 0.0f;
        }
    }
}
