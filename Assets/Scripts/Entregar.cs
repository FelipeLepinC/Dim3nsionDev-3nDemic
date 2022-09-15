using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Entregar : MonoBehaviour
{
    // Start is called before the first frame update
    private RoomManager gameManager;
    void Start()
    {
        
    }
    void Awake()
    {
        //direction = transform.TransformDirection(Vector3.forward) * 5;
        StartCoroutine(IdentificarPlayers());
        //ui_contador = GameObject.FindWithTag("MainCamera").GetComponent<AppleCounter>();
    }

    IEnumerator IdentificarPlayers()
    {
        yield return new WaitForSeconds(2);
        //ui_contador = GameObject.FindWithTag("MainCamera").GetComponent<AppleCounter>();
        gameManager = GameObject.FindWithTag("RoomManager").GetComponent<RoomManager>();
    }
    // Update is called once per frame
    void Update()
    {
        	if (Input.GetKeyDown(KeyCode.E)){
                Debug.Log("AAAAA");
                //candado = 0;
               gameManager.GetComponent<RoomManager>().EntregarManzanas();
               //StartCoroutine(abrirCandado());
         	   
        	}
    }
}
