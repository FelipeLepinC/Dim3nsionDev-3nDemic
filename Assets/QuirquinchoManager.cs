using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuirquinchoManager : MonoBehaviour
{
    public GameObject[] jugadores;
    public GameObject[] players;
    public int total;
    public int puntaje;
    private int contadorPlayer;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hola soy el Quirquincho Manager");
        puntaje = 0;
    }

    // Update is called once per frame
    void Update()
    {
        players = GameObject.FindGameObjectsWithTag("Jugador");
        foreach(GameObject player in players){
            contadorPlayer = player.gameObject.GetComponent<CameraCont>().contador;
            if (puntaje < contadorPlayer){
                puntaje = contadorPlayer;
            }
        } 
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
