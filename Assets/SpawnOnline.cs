using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class SpawnOnline : MonoBehaviour
{
    PhotonView view;
    //private Rigidbody rb;
    //private CharacterController cc;
    //public FPCSwimmerNormal FPC;
    // Start is called before the first frame update
    private Component[] array;
    void Start()
    {
        view = GetComponent<PhotonView>();
        //cc  = GetComponent<CharacterController>();
        //rb  = GetComponent<Rigidbody>();
        //FPC = GetComponent<FPCSwimmerNormal>();        
        //FPC.enabled = false;

        //array = GetComponents(typeof(Component));
        //for (int i = 0; i < array.Length; i++){
        //    Debug.Log(array[i].GetType().Name);
        //    array[i].GetType().enabled = false;
        //}

        MonoBehaviour[] comps = GetComponents<MonoBehaviour>();
        foreach(MonoBehaviour c in comps)
        {
            //Debug.Log(c.GetType().Name);
            //if(c.GetType().Name != "PhotonView" || c.GetType().Name != "SpawnOnline" ){
            //    c.enabled = false;
            //}
            if(c.GetType().Name == "FPCSwimmerNormal"){
                c.enabled = false;
                //Debug.Log("Se desactivará " + c.GetType().Name);
            }
            if(c.GetType().Name == "UnderWaterDetector"){
                c.enabled = false;
            }
            if(c.GetType().Name == "FPCSwimmer"){
                c.enabled = false;
            }
            //if(c.GetType().Name == "TrampasOnline"){
            //    c.enabled = false;
                //Debug.Log("Se desactivará " + c.GetType().Name);
            //}
        }
        this.GetComponent<SphereCollider>().enabled = false;
        this.GetComponent<Rigidbody>().isKinematic = false;
        //GetComponent<TrackRenderer>().enabled = true;

        
        
        for (int i = 0; i < gameObject.transform.childCount; i++)
                {
                    gameObject.transform.GetChild(i).gameObject.SetActive(false);
                    if(gameObject.transform.GetChild(i).tag == "Modelo" ){
                        //Debug.Log(gameObject.transform.GetChild(i).tag + " desactivada");
                        gameObject.transform.GetChild(i).gameObject.SetActive(true); //Se desactivan todos los componentes hijos de los jugadores nuevos para que no se mezclen con el actual
                    }
                    if(gameObject.transform.GetChild(i).tag == "Atrapado" ){
                        //Debug.Log(gameObject.transform.GetChild(i).tag + " desactivada");
                        gameObject.transform.GetChild(i).gameObject.SetActive(true); //Se desactivan todos los componentes hijos de los jugadores nuevos para que no se mezclen con el actual

                    }
                    
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine) // Se restringe la activación de componentes solo para el jugador entrante
        {
            //Debug.Log("SOY YOOOOOO");
            //Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), Input.GetAxisRaw("Up"));
            //transform.position += input.normalized * 6 * Time.deltaTime;
            MonoBehaviour[] comps = GetComponents<MonoBehaviour>();
            foreach(MonoBehaviour c in comps)
            {
                //Debug.Log(c.GetType().Name);
                c.enabled = true;
            }
            if (gameObject.GetPhotonView().IsMine){
                for (int i = 0; i < gameObject.transform.childCount; i++)
                {
                    //Debug.Log(gameObject.transform.GetChild(i).tag + " activada");
                    gameObject.transform.GetChild(i).gameObject.SetActive(true); //Se activan las componentes únicas del jugador entrante
                    if(gameObject.transform.GetChild(i).tag == "Atrapado" ){
                        //Debug.Log(gameObject.transform.GetChild(i).tag + " desactivada");
                        gameObject.transform.GetChild(i).gameObject.SetActive(false); //Se desactivan todos los componentes hijos de los jugadores nuevos para que no se mezclen con el actual
                    }
                }
            }
            this.GetComponent<SphereCollider>().enabled = true;
            this.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
