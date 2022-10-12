using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageType{
    player,
    enemy
}

public class DamageEnemy : MonoBehaviour
{

    DamageType type = DamageType.enemy;
    float damageEnemy = 10.0f;

    // Haciendole da�o al player
    private void OnTriggerEnter(Collider other){
        if(other.GetComponent<Health>() != null){
            if(other.GetComponent<Health>().type != type){
                other.GetComponent<Health>().RecibirDano(damageEnemy);
                GetComponent<Follow>().derrotado = true;
            }
        }
    }
}
