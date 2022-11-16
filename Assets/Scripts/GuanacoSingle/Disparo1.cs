using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo1 : MonoBehaviour
{
    public void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Colisi�n de disparo: " + collider.gameObject.name);
        if (collider.gameObject.name == "Walk(Clone)")
        {
            Destroy(collider.gameObject);
        }
    }
}
