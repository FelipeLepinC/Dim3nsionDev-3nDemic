using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charco : MonoBehaviour
{
    Transform transformInicialCharco;
    Vector3 escalaInicialCharco;
    public bool esAlcanzado = false;
    const float tiempoRestanteCharco = 60f; // cantidad de segundos para que se desaparezca
    float tiempoActualCharco = 0f;
    //Sonidos
    private SoundManager soundManager;
    void Start()
    {
        transformInicialCharco = gameObject.transform;
        escalaInicialCharco = gameObject.transform.localScale;
        soundManager = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (esAlcanzado)
        {
            // Comenzar a achicar hasta desaparecer
            tiempoActualCharco = tiempoActualCharco + Time.deltaTime;
            SecarLago();
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
            //aqui obtengo la posicion del charco
            HealthRana vidaRana = collision.gameObject.GetComponent<HealthRana>();
            vidaRana.set_checkpoint(transformInicialCharco.position);
        }
    }

    private void SecarLago()
    {
        float proporcionTiempo = tiempoActualCharco / tiempoRestanteCharco;
        gameObject.transform.localScale = new Vector3(escalaInicialCharco.x, escalaInicialCharco.y* (1-proporcionTiempo), escalaInicialCharco.z);
    }
}
