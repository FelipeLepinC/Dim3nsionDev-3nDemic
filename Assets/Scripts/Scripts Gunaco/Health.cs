using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Health : MonoBehaviourPunCallbacks
{
    public DamageType type; 
    public TimeControllerGuanaco terminar;
    Puntaje puntaje;

    void Start()
    {
        if (gameObject.tag == "Player")
        {
            type = DamageType.player;
        }
        else
        {
            type = DamageType.enemy;
            puntaje = GameObject.FindWithTag("Player").GetComponent<Puntaje>();
        }
    }


    public float HealthPoints{
        get{
            return healthPoints;
        }
        set{
            healthPoints = value;
            if (healthPoints <= 0){
                if (type == DamageType.enemy){
                    // Hacer que el personaje se destruya luego de alejarse
                    // GetComponent<Follow>().derrotado = true;
                    this.photonView.RPC("Derrotado", RpcTarget.AllBuffered, true);
                    // GetComponent<FollowGuanacos>().derrotado = true;
                    // puntaje.SumarPuntos(1);
                }
                else
                {
                    // SINCRONIZAR !!!
                    terminar.finished = true;
                    Debug.Log("Perdiste");
                }
            } 
        }
    }

    [PunRPC]
    public void Derrotado(bool valor)
    {
        GetComponent<FollowGuanacos>().derrotado = valor;
    }

    public void RecibirDano(float dano_recibido)
    {
        HealthPoints = HealthPoints - dano_recibido;
        this.photonView.RPC("ModificarVida", RpcTarget.AllBuffered, HealthPoints);
    }

    [PunRPC]
    public void ModificarVida(float HealthPoints_value){
        HealthPoints = HealthPoints_value;
    }

    public void AgregarFuerza(Vector3 salto_dano){
        this.photonView.RPC("EjercerFuerza", RpcTarget.AllBuffered, salto_dano);
    }

    [PunRPC]
    public void EjercerFuerza(Vector3 salto_dano){
        GetComponent<Rigidbody>().AddForce(salto_dano);
    }

    [SerializeField]
    private float healthPoints = 100.0f;

    public void RecibirDano_Only_Player(float dano_recibido)
    {
        HealthPoints = HealthPoints - dano_recibido;
    }
}
