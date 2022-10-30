using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoRayCast : MonoBehaviour
{
    bool shooting;
    float dano_saliva = 40.0f;

    public float cooldown_saliva = 0.0f;
    public const float COOLDOWN = 1.0f;
    
    void Update()
    {
        cooldown_saliva += Time.deltaTime;
        if (Input.GetKey(KeyCode.E) || OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0)
        {
            if (cooldown_saliva > COOLDOWN)
            {
                Debug.Log("Se puede disparar");
                shooting = true;
            }
            else{
                Debug.Log("En coolDown");
            }
        }
    }

    void FixedUpdate()
    {
        if(shooting)
        {
            cooldown_saliva = 0;
            shooting = false;
            RaycastHit hit;
            if(Physics.Raycast(transform.position, Vector3.forward, out hit, 300f)){
                if(hit.transform.tag == "punto"){
                    Debug.Log("Disparando al puma");
                    GameObject puma = hit.transform.gameObject;

                    puma.GetComponent<Health>().RecibirDano(dano_saliva);
                    Vector3 salto_dano = (puma.transform.up * 350) + (puma.transform.forward * -1 * 100);
                    puma.GetComponent<Rigidbody>().AddForce(salto_dano); // Hacer que el enemigo salte cuando recibe saliva
                    // Destroy(collider.gameObject); # Creo que se destruye la saliva
                }
            }
        }
    }
}
