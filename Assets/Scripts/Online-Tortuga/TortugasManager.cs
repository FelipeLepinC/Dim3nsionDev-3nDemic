using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TortugasManager : MonoBehaviour
{
    public GameObject[] jugadores;
    public int total;
    private int estado;
    private int secondLock;
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

    IEnumerator MostrarEstado(){
        secondLock = 1;
        Debug.Log("Hola amigos soy el Tortugas Manager : " + estado);
        yield return new WaitForSeconds(2);
        secondLock = 0;
    }
}
