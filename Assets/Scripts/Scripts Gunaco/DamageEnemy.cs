using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public enum DamageType{
    player,
    enemy
}

public class DamageEnemy : MonoBehaviourPunCallbacks
{

    DamageType type = DamageType.enemy;
    float damageEnemy = 10.0f;

    // Haciendole da�o al player
    private void OnTriggerEnter(Collider other){
        if(other.GetComponent<Health>() != null){
            if(other.GetComponent<Health>().type != type){
                other.GetComponent<Health>().RecibirDano_Only_Player(damageEnemy);
                // GetComponent<Follow>().derrotado = true;
                //GetComponent<FollowGuanacos>().derrotado = true;
                this.photonView.RPC("DerrotadoPlayer", RpcTarget.AllBuffered, true);
            }
        }
    }

     [PunRPC]
    public void DerrotadoPlayer(bool valor)
    {
        GetComponent<FollowGuanacos>().derrotado = valor;
    }
}
