using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ControllerPlayerTemporal : MonoBehaviour
{
    // Start is called before the first frame update
    PhotonView view;
    void Start()
    {
        this.GetComponent<CharacterController>().enabled = false;
        //this.GetComponent<XROrigin>().enabled = false;
        //this.GetComponent<ContinuousMovement>().enabled = false;
        //this.GetComponent<LocomotionSystem>().enabled = false;
        //this.GetComponent<LocomotionController>().enabled = false;
        //this.GetComponent<TeleportationProvider>().enabled = false;
        MonoBehaviour[] comps = GetComponents<MonoBehaviour>();
        
        foreach(MonoBehaviour c in comps)
        {
            if(c.GetType().Name == "XROrigin"){
                c.enabled = false;
            }
            if(c.GetType().Name == "ContinuousMovement"){
                c.enabled = false;
            }
            if(c.GetType().Name == "LocomotionSystem"){
                c.enabled = false;
            }
            if(c.GetType().Name == "LocomotionController"){
                c.enabled = false;
            }
            if(c.GetType().Name == "TeleportationProvider"){
                c.enabled = false;
            }
        }
        transform.Rotate(0,0,180);
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
            // this.GetComponent<CharacterController>().enabled = true;
            //MonoBehaviour[] comps = GetComponents<MonoBehaviour>();
            this.GetComponent<CharacterController>().enabled = true;
            foreach(MonoBehaviour c in comps)
            {
                if(c.GetType().Name == "XROrigin"){
                    c.enabled = true;
                }
                if(c.GetType().Name == "ContinuousMovement"){
                    c.enabled = true;
                }
                if(c.GetType().Name == "LocomotionSystem"){
                    c.enabled = true;
                }
                if(c.GetType().Name == "LocomotionController"){
                    c.enabled = true;
                }
                if(c.GetType().Name == "TeleportationProvider"){
                    c.enabled = true;
                }
            }
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
