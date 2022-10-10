using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TortugasManager : MonoBehaviour
{
    public GameObject[] jugadores;
    public int total;
    private int estado;
    private int secondLock;
    private float distancia;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hola soy el Tortuga Manager");
        secondLock = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (secondLock == 0){
            StartCoroutine(MostrarEstado());
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

    public void JugadorLlama(){
        Debug.Log("Tortuga Manager ha respondido");
    }

    IEnumerator MostrarEstado(){
        jugadores = GameObject.FindGameObjectsWithTag("Player");
        distancia = Vector3.Distance(jugadores[0].transform.position, jugadores[1].transform.position);
        Debug.Log("Hay" + jugadores.Length + " jugadores en la sala");
        Debug.Log("La distancia entre los jugadores es: " + distancia);
        foreach(GameObject p in jugadores){
            Debug.Log("El estado del jugador es:" + p.GetComponent<TrampasOnline>().estado );
        }
        secondLock = 1;
        if (estado == 0){
            Debug.Log("Tortuga es libre");
        }
        if (estado == 1){
            Debug.Log("Tortuga está atrapada ayúdenla");
        }
        
        yield return new WaitForSeconds(2);
        secondLock = 0;
    }
}
