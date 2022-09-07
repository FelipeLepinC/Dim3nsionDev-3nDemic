using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeEnergia : MonoBehaviour
{
    public Image barraDeEnergia;

    public float energiaActual;

    public float energiaMaxima;


    // Update is called once per frame
    void Update()
    {
        barraDeEnergia.fillAmount = energiaActual / energiaMaxima;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Alimento")
        {
            energiaActual = energiaActual + 10;
            barraDeEnergia.fillAmount = energiaActual / energiaMaxima;
        }
        else if (collision.gameObject.tag == "NoAlimento")
        {
            energiaActual = energiaActual - 10;
            barraDeEnergia.fillAmount = energiaActual / energiaMaxima;
        }
    }
}
