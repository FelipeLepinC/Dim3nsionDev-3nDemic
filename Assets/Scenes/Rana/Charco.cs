using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charco : MonoBehaviour
{
    Transform transformCharco;
    bool esAlcanzado = false;
    const float tiempoRestanteCharco = 60f; // cantidad de segundos para que se desaparezca
    float tiempoActualCharco = 0f;
    void Start()
    {
        transformCharco = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (esAlcanzado)
        {
            // Comenzar a achicar hasta desaparecer
            tiempoActualCharco = tiempoActualCharco + Time.deltaTime;
            if (tiempoActualCharco > tiempoRestanteCharco)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            esAlcanzado = true;
        }
    }
}
