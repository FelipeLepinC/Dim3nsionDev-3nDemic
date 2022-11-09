using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.XR.CoreUtils;

public class HealthRana : MonoBehaviour
{
    TimeControllerRana timeControllerRana;
    public int sin_tp = 0;
    public Vector3 ultimoCheckpoint; //este vector debe tener el tp inicial
    public bool necesitaSerTeletransportadoVR = false;

    void Start()
    {
        timeControllerRana = GameObject.Find("PanelTiempo").GetComponent<TimeControllerRana>();
        ultimoCheckpoint = new Vector3(436.5181f, 9.9086f, 860.087f);
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
        float delta_x = gameObject.transform.position.x - ultimoCheckpoint.x;
        float delta_y = gameObject.transform.position.y - ultimoCheckpoint.y;
        float delta_z = gameObject.transform.position.z - ultimoCheckpoint.z;
        Vector3 finalDirection = new Vector3(-delta_x,-delta_y,-delta_z);
        Debug.Log(finalDirection);
        gameObject.GetComponent<CharacterController>().Move(finalDirection);
    }

    public void setNecesitaSerTeletransportadoVR(bool opcion)
    {
        necesitaSerTeletransportadoVR = opcion;
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
        ultimoCheckpoint = posicion;
    }

    [SerializeField]
    private float healthPoints = 100.0f;
}