using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverTrampas : MonoBehaviour
{
    public Rigidbody rbPlayer;

    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colision Detectada");
        GameObject objetoColisionado = collision.gameObject;
        if (objetoColisionado != null && objetoColisionado.tag == "Trampa")
        {
            Destroy(objetoColisionado);
            Debug.Log("Objeto Destruido");
        }
    }
}
