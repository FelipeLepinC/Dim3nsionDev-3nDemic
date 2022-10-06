using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TortugasManager : MonoBehaviour
{
    public GameObject[] jugadores;
    public int total;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hola soy el Tortuga Manager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActualizarContador(int t)
    {
        total += t;
        Debug.Log("El total de la sesión es: " + total);
        jugadores = GameObject.FindGameObjectsWithTag("Jugador");
        foreach(GameObject p in jugadores){
            p.GetComponent<CameraCont>().ContadorTotal(5);
            Debug.Log("Hola soy un jugador");
            //p.GetComponent<AppleCounter>().InHomeForAll(total);
        }


    }
}
