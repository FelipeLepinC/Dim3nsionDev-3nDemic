using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mosquito : MonoBehaviour
{
    const float vidaAgregada = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            HealthRana vidaPlayer = collision.gameObject.GetComponent<HealthRana>();
            vidaPlayer.GanarVida(vidaAgregada);
            Destroy(gameObject);
        }
    }
}
