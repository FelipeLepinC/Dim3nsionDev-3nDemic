using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GuanacosManager : MonoBehaviour
{
    public GameObject[] jugadores;
    public int total;
    GameObject playercamera;
    GameObject saliva;
    public float cooldown_saliva = 0.0f;
    public const float COOLDOWN = 1.0f;
    float velocidad_disparo = 5000.0f;
    int cantidad_disparos = 0;
    public int puntos = 0;
    PhotonView view;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hola soy el Guanacos Manager");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cooldown_saliva += Time.deltaTime;
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

    public void Shoot(int num_disparo){
        playercamera = GameObject.Find("Main Camera");
        if (playercamera == null)
        {
            playercamera = GameObject.Find("CenterEyeAnchor");
        }
        saliva = GameObject.Find("Saliva");
        cooldown_saliva = 0;
        GameObject BalaTemporal = PhotonNetwork.Instantiate(saliva.name+"1", playercamera.transform.position + new Vector3 (0,- 0.5f,0), playercamera.transform.rotation) as GameObject;
        BalaTemporal.name = $"Disparo_{num_disparo}";
        BalaTemporal.tag = "Saliva";
        Rigidbody rbBalaTemporal = BalaTemporal.GetComponent<Rigidbody>();
        Vector3 direccion_disparo = playercamera.transform.forward;
        rbBalaTemporal.AddForce(direccion_disparo * velocidad_disparo);
        Destroy(BalaTemporal, 5.0f);
    }

    public void SumarPuntos(int cuantos){
        puntos += cuantos;
        //view.RPC("Actualizar", RpcTarget.OthersBuffered, puntos);
    
    }
    /*
    [PunRPC]
    public void Actualizar(int valor){
        puntos = valor;
    }
    */
}
