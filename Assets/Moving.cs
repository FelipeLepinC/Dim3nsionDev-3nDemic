using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public GameObject jugador;
    public GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler( 0, camera.transform.eulerAngles.y, 0);
        //this.gameObject.transform.position = jugador.gameObject.transform.position + new Vector3(0,0,0);
        //this.gameObject.transform.rotation = camera.gameObject.transform.rotation;
    }
}
