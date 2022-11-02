using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public DamageType type; 
    public TimeControllerGuanaco terminar;
    Puntaje puntaje;
    GuanacosManager puntos;

    void Start()
    {
        Debug.Log("Mi vida inicial es: " + healthPoints);
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
                    puntos = GameObject.FindWithTag("GameManager").GetComponent<GuanacosManager>();
                    puntos.SumarPuntos(1);
                    // GetComponent<Follow>().derrotado = true;
                    GetComponent<FollowGuanacos>().derrotado = true;
                    //puntaje.SumarPuntos(1);
                }
                else
                {
                    terminar.finished = true;
                    Debug.Log("Perdiste");
                }
            } 
        }
    }

    public void RecibirDano(float dano_recibido)
    {
        //dano_recibido = 20.0f;
        HealthPoints = HealthPoints - dano_recibido;
        Debug.Log("Me quedan " + HealthPoints + "de vida");
    }

    [SerializeField]
    private float healthPoints = 100.0f;
}
