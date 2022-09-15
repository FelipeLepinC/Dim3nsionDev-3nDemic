using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TortugaAtrapada : MonoBehaviour
{
    bool atrapada;
    Rigidbody rbTortugaAtrapada;
    float tiempoLiberada = 0.0f;
    float tiempoLiberacion = 5.0f;

    void Start()
    {
        rbTortugaAtrapada = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!atrapada)
        {
            rbTortugaAtrapada.AddForce(Vector3.up * (rbTortugaAtrapada.mass * 10)); // alejandose de la trampa
            tiempoLiberada += Time.deltaTime;
            if (tiempoLiberada > tiempoLiberacion)
            {
                Destroy(this.gameObject);
                Debug.Log("Liberada");
                // A�adir la l�gica de contar tortugas
            }
            //Debug.Log("Corriendo por su vida - " + tiempoLiberada);
        }
    }

    void OnCollisionStay(Collision trampa)
    {
        if (trampa.gameObject.tag == "TrampaNPC")
        { 
            atrapada = true;
            tiempoLiberada = 0.0f;
            //Debug.Log("Tortuga Atrapada");
        }
    }

    void OnCollisionEnter(Collision trampa)
    {
        if (trampa.gameObject.tag == "TrampaNPC")
        { 
            atrapada = true;
            tiempoLiberada = 0.0f;
            //Debug.Log("Tortuga Atrapada");
        }
    }

    void OnCollisionExit(Collision other)
    {
        atrapada = false;
        //Debug.Log("Tortuga Liberada");
    }
}
