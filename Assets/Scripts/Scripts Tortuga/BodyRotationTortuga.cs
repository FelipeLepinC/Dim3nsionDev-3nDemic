using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyRotationTortuga : MonoBehaviour
{
    public GameObject camara;
    // Start is called before the first frame update
    void Start()
    {
        camara = GameObject.Find("CenterEyeAnchor");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.rotation = camara.transform.rotation;
    }
}
