using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarModelo : MonoBehaviour
{
    public Camera Camera;
    // Start is called before the first frame update
    void Start()
    {
        //transform.Rotate(0,0,180);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,transform.localEulerAngles.y,0);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(0,0,180);
        //transform.rotation = Quaternion.LookRotation(-Camera.main.transform.forward + new Vector3(270f,270f,180f), Camera.main.transform.up );
        //transform.LookAt(Camera.main.transform.position, -Vector3.up);
        //Vector3 upAxis = Vector3.up;
        //transform.localEulerAngles = new Vector3(0,transform.localEulerAngles.y,0);
        //transform.localEulerAngles = new Vector3(0,transform.localEulerAngles.y,0);
        transform.rotation = Quaternion.Euler( 0, Camera.transform.eulerAngles.y, 180);
        //Vector3 upAxis = Vector3.up;
        //transform.rotation = Quaternion.LookRotation(Vector3.Cross(upAxis,  Vector3.Cross(upAxis, Camera.main.transform.forward)), upAxis);
    }
}
