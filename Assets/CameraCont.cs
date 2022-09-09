using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraCont : MonoBehaviour
{
    PhotonView view;
    public GameObject camera;
    public GameObject player;
    // Start is called before the first frame update
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
    }
    // Update is called once per frame
    void Update()
    {
        if (view.IsMine) // Se restringe la activación de componentes solo para el jugador entrante
        {
            Debug.Log("SOY YOOOOOO");
            //Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), Input.GetAxisRaw("Up"));
            //transform.position += input.normalized * 6 * Time.deltaTime;
            if (gameObject.GetPhotonView().IsMine){
                for (int i = 0; i < gameObject.transform.childCount; i++)
                {
                    gameObject.transform.GetChild(i).gameObject.SetActive(true); //Se activan las componentes únicas del jugador entrante
                }
            }
        }
    }
}
