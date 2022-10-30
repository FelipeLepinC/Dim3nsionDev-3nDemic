using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour
{
    public float cooldown_saliva = 0.0f;
    public const float COOLDOWN = 1.0f;

    float velocidad_disparo = 5000.0f;
    int cantidad_disparos = 0;

    GameObject playercamera;
    GameObject saliva;
    GameObject[] guanacoManager;

    public void Start()
    {
        playercamera = GameObject.Find("Main Camera");
        if (playercamera == null)
        {
            playercamera = GameObject.Find("CenterEyeAnchor");
        }
        saliva = GameObject.Find("Saliva");
        
    }

    void FixedUpdate()
    {
        guanacoManager = GameObject.FindGameObjectsWithTag("GameManager");
        //Debug.Log(guanacoManager.Length);
        cooldown_saliva += Time.deltaTime;
        if (Input.GetKey(KeyCode.E) || OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0)
        { 
            if (cooldown_saliva > COOLDOWN) 
            {
                cooldown_saliva = 0;
                guanacoManager[0].GetComponent<GuanacosManager>().Shoot(++cantidad_disparos);
            }
        }
    }

    /*
    void Shoot(int num_disparo){
        cooldown_saliva = 0;
        GameObject BalaTemporal = Instantiate(saliva, playercamera.transform.position, playercamera.transform.rotation) as GameObject;
        BalaTemporal.name = $"Disparo_{num_disparo}";
        BalaTemporal.tag = "Saliva";
        Rigidbody rbBalaTemporal = BalaTemporal.GetComponent<Rigidbody>();
        Vector3 direccion_disparo = playercamera.transform.forward;
        rbBalaTemporal.AddForce(direccion_disparo * velocidad_disparo);
        Destroy(BalaTemporal, 5.0f);
    }
    */
}
