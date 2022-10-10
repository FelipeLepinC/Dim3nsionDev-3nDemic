using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TrampasOnline : MonoBehaviour
{
    GameObject[] enemies;
    public int estado;
    private int mylock;
    PhotonView view;
    BarraDeEnergia barra;
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        barra = GetComponent<BarraDeEnergia>();
        estado = 0;
        mylock = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (mylock == 0){
            StartCoroutine(Sumar());
            Debug.Log("Mi estado es:" + estado);
            if (view.IsMine){
                //Debug.Log("Mi estado es:" + estado);
            }
        }
        
        if (Input.GetKeyDown("space")){
            view.RPC("RPC_SumarOnline", RpcTarget.OthersBuffered);
            //view.RPC(nameof(barra.Liberado), RpcTarget.OthersBuffered);
            if (view.IsMine){
                //Debug.Log("Mi estado Online es:" + estado);
                //view.RPC("RPC_SumarOnline", RpcTarget.OthersBuffered);
            }
            
            //estado += 1;
            //Debug.Log("Space fue presionado");
            //Debug.Log(estado);
            enemies = GameObject.FindGameObjectsWithTag("GameManager");
            Debug.Log(enemies.Length);
            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponent<TortugasManager>().JugadorLlama();
                Debug.Log("Hay un Manager en la sala");
            }        

        }
    }    
    IEnumerator Sumar(){
        mylock = 1;
        yield return new WaitForSeconds(2);
        if (estado >= 10){
            estado -= 2;
            barra.Liberado();
        }
        //SumarOnline();
        //view.RPC("RPC_SumarOnline", RpcTarget.OthersBuffered);
        //Debug.Log("XD");

        mylock = 0;
    }

    [PunRPC]
    void RPC_SumarOnline(){
        Debug.Log("Entré a función RPC");
        estado += 5;
        Debug.Log("Salí de función RPC");
    }
}
