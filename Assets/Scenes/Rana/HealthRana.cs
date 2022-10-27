using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthRana : MonoBehaviour
{
    TimeControllerRana timeControllerRana;

    void Start()
    {
        timeControllerRana = GameObject.Find("PanelTiempo").GetComponent<TimeControllerRana>();
    }


    public float HealthPoints
    {
        get
        {
            return healthPoints;
        }
        set
        {
            healthPoints = value;
            if (healthPoints <= 0)
            {
                // Teletransportar hacia el último charco
                timeControllerRana.Rostizado();
                HealthPoints = 100.0f;
            }
        }
    }

    public void RecibirDano(float dano_recibido)
    {
        HealthPoints = HealthPoints - dano_recibido;
    }

    public void GanarVida(float vida_recibida)
    {
        HealthPoints = HealthPoints + vida_recibida;
    }

    [SerializeField]
    private float healthPoints = 100.0f;
}