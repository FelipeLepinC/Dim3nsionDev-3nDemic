using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chocando : MonoBehaviour
{
    private void OnCollisionEnter(Collision other){
        if (other.gameObject.tag == "caja")
        {
            Debug.Log("El player esta colisionando con la caja");
        }
    }
}
