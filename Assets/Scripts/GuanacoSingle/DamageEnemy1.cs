using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageType1{
    player,
    enemy
}

public class DamageEnemy1 : MonoBehaviour
{

    DamageType1 type = DamageType1.enemy;
    float damageEnemy = 10.0f;

    // Haciendole da�o al player
    private void OnTriggerEnter(Collider other){
        if(other.GetComponent<Health1>() != null){
            if(other.GetComponent<Health1>().type != type){
                other.GetComponent<Health1>().RecibirDano(damageEnemy);
                GetComponent<Follow1>().derrotado = true;
            }
        }
    }
}
