using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltoRana : MonoBehaviour
{
    Rigidbody rb;
    bool saltando = false;
    float fuerzaDeSalto = 4f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Boton uno: " + Input.GetButtonDown("One"));
        if (!saltando && Input.GetButtonDown("One"))
        {
            rb.AddForce(new Vector3(0, fuerzaDeSalto, 0));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Agua" || collision.gameObject.tag == "Terrain")
        {
            saltando = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Terrain")
        {
            saltando = true;
        }
    }
}
