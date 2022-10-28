using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthRana : MonoBehaviour
{
    TimeControllerRana timeControllerRana;
    public int sin_tp = 0;
    public Vector3 ultimo_checkpoint = new Vector3(573, 20, 588); //este vector debe tener el tp inicial

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
                RpcRespawn();
                HealthPoints = 100.0f;
            }
        }
    }

    void RpcRespawn()
    {
        // move back to zero location
        transform.position = ultimo_checkpoint;
    }

    public void RecibirDano(float dano_recibido)
    {
        HealthPoints = HealthPoints - dano_recibido;
    }

    public void GanarVida(float vida_recibida)
    {
        HealthPoints = HealthPoints + vida_recibida;
    }

    public void set_checkpoint(Vector3 posicion)
    {
        ultimo_checkpoint = posicion;
    }

    [SerializeField]
    private float healthPoints = 100.0f;
}