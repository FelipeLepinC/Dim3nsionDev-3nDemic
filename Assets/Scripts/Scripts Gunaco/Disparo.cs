using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Colisión de disparo: " + collider.gameObject.name);
        if (collider.gameObject.name == "Walk(Clone)")
        {
            Destroy(collider.gameObject);
        }
    }
}
