using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoMultiplayer : MonoBehaviour
{
    GameObject[] Paneles;
    TimeControllerRanaMultiplayer ControlerReferencia;
    private Vector3 currentPos;
    private Quaternion currentRot;
    public LayerMask targetMask;

    void Start()
    {
        currentPos = gameObject.transform.localPosition ;
        currentRot = gameObject.transform.localRotation;
        Paneles = GameObject.FindGameObjectsWithTag("PanelTiempo");
        ControlerReferencia = Paneles[0].GetComponent<TimeControllerRanaMultiplayer>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (ControlerReferencia.cantTotalJugadores == ControlerReferencia.cantJugadoresColisionandoObstaculo)
        // {
        //     // Mover obstaculo
            // Rigidbody rb = GetComponent<Rigidbody>();
            // rb.mass = 1;
        // }
        FindVisibleTargets();
    }

    public void FindVisibleTargets()
	{
		// visibleTargets.Clear();
		// Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);
        Collider[] targetsInViewRadius = Physics.OverlapBox(gameObject.transform.position, transform.localScale, Quaternion.identity, targetMask);
        Debug.Log("Se han detectado : "+targetsInViewRadius.Length+" jugadores");
		if(gameObject.tag == "Tronco")
        {
            if(targetsInViewRadius.Length >= 3)
            {
                Debug.Log("Se esta moviendo el obstaculo");
                moverObstaculo();
            }
            else 
            {
                noMoverObstaculo();
            }
        }
        else if(gameObject.tag == "Branches")
        {
            if(targetsInViewRadius.Length >= 2) 
            {
                Debug.Log("Se esta moviendo el obstaculo");
                moverObstaculo();
            }
            else noMoverObstaculo();
        }
	}

    public void moverObstaculo(){
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.mass = 1;
        gameObject.transform.position = gameObject.transform.position;
        gameObject.transform.rotation =  gameObject.transform.rotation;
        currentPos = gameObject.transform.position;
        currentRot = gameObject.transform.rotation;
    }

    public void noMoverObstaculo(){
        // gameObject.transform.position = currentPos;
        // gameObject.transform.rotation = currentRot;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.mass = 5000000;
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "mosca")
        {
            Physics.IgnoreCollision(other.gameObject.GetComponent<CapsuleCollider>(), GetComponent<MeshCollider>());
        }
    }

    /*
    public void moverObstaculo(){
        gameObject.transform.position = gameObject.transform.position;
        gameObject.transform.rotation =  gameObject.transform.rotation;
        currentPos = gameObject.transform.position;
        currentRot = gameObject.transform.rotation;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.mass = 1;
    }

    public void noMoverObstaculo(){
        gameObject.transform.position = currentPos;
        gameObject.transform.rotation = currentRot;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.mass = 5000000;
    }
    */

    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.gameObject.tag == "Player")
    //     {
    //         for (int i = 0; i < ControlerReferencia.cantTotalJugadores; i++)
    //         {
    //             GameObject panel = Paneles[i];
    //             panel.GetComponent<TimeControllerRanaMultiplayer>().JugadorColisionandoObstaculo();
    //         }
    //     }
    // }
    // private void OnCollisionExit(Collision collision)
    // {
    //     if (collision.gameObject.tag == "Player")
    //     {
    //         for (int i = 0; i < ControlerReferencia.cantTotalJugadores; i++)
    //         {
    //             GameObject panel = Paneles[i];
    //             panel.GetComponent<TimeControllerRanaMultiplayer>().JugadorNoColisionandoObstaculo();
    //         }
    //     }
    // }
}
