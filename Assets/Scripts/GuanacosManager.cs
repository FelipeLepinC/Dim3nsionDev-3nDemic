using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuanacosManager : MonoBehaviour
{
    public GameObject[] jugadores;
    public int total;
    public int puntos = 0;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hola soy el Guanacos Manager");
    }

    // Update is called once per frame
    void Update()
    {
        jugadores = GameObject.FindGameObjectsWithTag("Player");
        if (jugadores.Length == 0){
            Debug.Log("Perdieron :( el puntaje logrado fue: " + puntos);
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

    public void SumarPuntos(){
        puntos = puntos + 1;
    }
}
