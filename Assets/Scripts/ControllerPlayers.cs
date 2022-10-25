using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ControllerPlayers : MonoBehaviour
{
    PhotonView view;
    public GameObject camera;
    public GameObject player;
    public int contador;

     public int counter;
    public int local;
    public int counter2;
    public int reset = 1;
    public int suma = 0;
    public int ganador;

    void Start()
    {
        view = GetComponent<PhotonView>();
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if(gameObject.transform.GetChild(i).tag != "Capsula"){
                Debug.Log(gameObject.transform.GetChild(i).tag + " desactivada");
                gameObject.transform.GetChild(i).gameObject.SetActive(false); //Se desactivan todos los componentes hijos de los jugadores nuevos para que no se mezclen con el actual
            }  
        }

        if (view.IsMine)
        {
            if (gameObject.GetPhotonView().IsMine){
                for (int i = 0; i < gameObject.transform.childCount; i++)
                {
                    gameObject.transform.GetChild(i).gameObject.SetActive(true); //Se activan las componentes únicas del jugador entrante
                    // if(gameObject.transform.GetChild(i).tag == "MainCameraVR"){
                    //     Debug.Log(gameObject.transform.GetChild(i).tag + " desactivada");
                    //     gameObject.transform.GetChild(i).gameObject.SetActive(false); //Se desactivan todos los componentes hijos de los jugadores nuevos para que no se mezclen con el actual
                    // }
                }
            }
        }
    }


}
