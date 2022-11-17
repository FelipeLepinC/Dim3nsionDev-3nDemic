using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;

public class DisparoRayCast : MonoBehaviour
{
    bool shooting;
    float dano_saliva = 15.0f;

    public float cooldown_saliva = 0.0f;
    public const float COOLDOWN = 1.0f;
    public GameObject camera;

    //Oculus
    public XRNode inputSource;
    private Vector2 inputAxis;
    private bool primaryButtonState;
    private XROrigin rig;

    private void Start() {
        
    }

    
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.triggerButton, out primaryButtonState);
        cooldown_saliva += Time.deltaTime;
        Debug.Log(primaryButtonState);
        if (Input.GetKey(KeyCode.E) || OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0 || primaryButtonState)
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
            if(Physics.Raycast(transform.position, camera.transform.forward, out hit, 1000f)){
                if(hit.transform.tag == "punto"){
                    Debug.Log("Disparando al puma");
                    GameObject puma = hit.transform.gameObject;

                    puma.GetComponent<Health>().RecibirDano(dano_saliva);
                    Vector3 salto_dano = (puma.transform.up * 350) + (puma.transform.forward * -1 * 100);
                    // puma.GetComponent<Rigidbody>().AddForce(salto_dano); // Hacer que el enemigo salte cuando recibe saliva
                    puma.GetComponent<Health>().AgregarFuerza(salto_dano);
                    // Destroy(collider.gameObject); # Creo que se destruye la saliva
                }
            }
        }
    }
}
