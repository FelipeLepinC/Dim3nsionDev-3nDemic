using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health1 : MonoBehaviour
{
    public DamageType1 type; 
    public TimeControllerGuanaco1 terminar;
    Puntaje1 puntaje;
    Tutorial tuto;

    void Start()
    {
        if (gameObject.tag == "Player")
        {
            type = DamageType1.player;
        }
        else
        {
            type = DamageType1.enemy;
            puntaje = GameObject.FindWithTag("Player").GetComponent<Puntaje1>();
            if(puntaje.tutorial){
                tuto = GameObject.FindWithTag("Player").GetComponent<Tutorial>();
            }
        }
        
    }


    public float HealthPoints{
        get{
            return healthPoints;
        }
        set{
            healthPoints = value;
            if (healthPoints <= 0){
                if (type == DamageType1.enemy){
                    // Hacer que el personaje se destruya luego de alejarse
                    GetComponent<Follow1>().derrotado = true;
                    puntaje.SumarPuntos(1);
                    tuto.murio = true;
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
        HealthPoints = HealthPoints - dano_recibido;
    }

    [SerializeField]
    private float healthPoints = 100.0f;
}
