using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Posicion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.position = this.gameObject.transform.position - new Vector3(0.0f,1.0f,0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(this.gameObject.transform.position);
        //if (this.gameObject.transform.position == new Vector3(0.0f,1.1176f,0.0f)){
        //    this.gameObject.transform.position = this.gameObject.transform.position - new Vector3(0,1,0);
        //}
        //this.gameObject.transform.position = this.gameObject.transform.position - new Vector3(0.0f,1.0f,0.0f);
    }
}
