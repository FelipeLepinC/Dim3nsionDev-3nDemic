using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float dano_saliva = 40.0f;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Saliva")
        {
            Debug.Log("Disparo recibido");
            GetComponent<Health>().RecibirDano(dano_saliva);
            Vector3 salto_dano = (gameObject.transform.up * 350) + (gameObject.transform.forward * -1 * 100);
            GetComponent<Rigidbody>().AddForce(salto_dano); // Hacer que el enemigo salte cuando recibe saliva
            Destroy(collider.gameObject);
        }
    }
}
