using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rostizandose : MonoBehaviour
{
    GameObject alerta;
    HealthRana vida;
    // Start is called before the first frame update
    void Start()
    {
        vida = GetComponent<HealthRana>();
        alerta = GameObject.Find("alert");
        alerta.SetActive(false);
    }

    // Update is called once per frame
    private void OnCollisionStay(Collision collision)
    {
        string tag = collision.gameObject.tag;
        if (tag != "Agua" && tag != "Finish" && tag != "Obstaculo") // Si no está pisando agua o está en la meta
        {
            vida.RecibirDano(0.5f);
            alerta.SetActive(true);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag != "Agua") // Si no está pisando agua
        {
            alerta.SetActive(false);
        }
    }
}
