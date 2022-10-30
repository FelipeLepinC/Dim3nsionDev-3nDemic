using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalivaCollider : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Disparo al puma");
        if (other.gameObject.tag == "punto")
        {
            Debug.Log("Disparo al puma");
        }
    }
}
