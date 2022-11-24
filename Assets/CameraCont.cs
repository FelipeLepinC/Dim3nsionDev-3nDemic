using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraCont : MonoBehaviour
{
    PhotonView view;
    public GameObject camera;
    public GameObject player;
    public GameObject manager;
    public GameObject[] managers;
    public int contador;

    public int counter;
    public int local;
    public int counter2;
    public int reset = 1;
    public int suma = 0;
    public int ganador;
    // Start is called before the first frame update
    void Start()
    {
        managers = GameObject.FindGameObjectsWithTag("GameManager");
        manager = managers[0];
        Debug.Log("cantidad de managers: "+ managers.Length);
        view = GetComponent<PhotonView>();
        //activar();
    }
    
    // Update is called once per frame
    void Update()
    {
        managers = GameObject.FindGameObjectsWithTag("GameManager");
        manager = managers[0];
        Debug.Log("cantidad de managers: "+ managers.Length);
        view = GetComponent<PhotonView>();
        if (contador < manager.gameObject.GetComponent<QuirquinchoManager>().puntaje){
            contador = manager.gameObject.GetComponent<QuirquinchoManager>().puntaje;
        }
        Debug.Log("Contador : "+contador);
        if (counter == 1 && reset == 2){
            counter = 1;
        }
        if (counter == 2 && reset == 2){
            counter = 2;
        }
        if (counter == 3 && reset == 2){
            Debug.Log("Debería entrar aquí no??");
            counter = 3;
        }
        if (counter == 4 && reset == 2){
            counter = 4;
        }
        if (counter == 5 && reset == 2){
            counter = 5;
        }
        if (counter == 6 && reset == 2){
            counter = 6;
        }
        if (counter == 7 && reset == 2){
            counter = 7;
        }
        if (counter == 8 && reset == 2){
            counter = 8;
        }
        if (counter == 9 && reset == 2){
            counter = 9;
        }
        if (counter == 10 && reset == 2){
            counter = 10;
        }
        if (counter == 11 && reset == 2){
            counter = 11;
        }
        if (counter == 12 && reset == 2){
            counter = 12;
        }
        if (counter == 13 && reset == 2){
            counter = 13;
        }
        if (counter == 14 && reset == 2){
            counter = 14;
        }
        if (counter == 15 && reset == 2){
            counter = 15;
        }
        if (counter == 16 && reset == 2){
            counter = 16;
        }
        if (counter == 17 && reset == 2){
            counter = 17;
        }
        if (counter == 18 && reset == 2){
            counter = 18;
        }
        //Debug.Log(counter);
        //if (counter == 20){
        //    counter = 20;
        //}

        else if(reset == 0 && reset == 0){
            camera.gameObject.GetComponent<AppleCounter>().counter = 0;
             counter = 0;
             //reset = 1;
        }
        else if (reset == 1 ){
            counter = camera.gameObject.GetComponent<AppleCounter>().counter; //se actualiza porque
        }

        if (view.IsMine) // Se restringe la activación de componentes solo para el jugador entrante
        {
            //desactivar();
        }
    }

    public void ContadorTotal(int t)
    {
        Debug.Log(contador);
        if (view.IsMine){
            view.RPC("RPC_Function", RpcTarget.AllBuffered, t);
        }
        
        //camera.gameObject.GetComponent<AppleCounter>().InHomeForAll(contador);
    }

    public void RepartirManzanas(){
        int t = counter;
        if (view.IsMine){
            reset = 0;
        }
        view.RPC("RPC_Function2", RpcTarget.AllBuffered, ganador);
    }


    [PunRPC]
    void RPC_Function(int a)
    {
        contador = a + contador;
    }

    [PunRPC]
    void RPC_Function2(int a)
    {
        //counter = a + counter2;
        Debug.Log("Mi contador local es: " + counter);
        Debug.Log("Mi contador sincronizado es: "+ a);
        
        if (reset != 0)
        {
            counter = a;
            Debug.Log("AHORA MI CONTADOR ES: " + counter);
            reset = 2;
        }
        else {
            counter = 0;
            Debug.Log("PERO MI CONTADOR AHORA ES: " + counter);
            
        }
        /* TRUCAZO */
        suma = a;
        if(view.IsMine){
            suma = suma -2;
        }
        Debug.Log("Se añadira" + suma + " al otro jugador");
    }

    void activar(){
        ////view = GetComponent<PhotonView>();
        for (int i = 0; i < gameObject.transform.childCount; i++)
                {
                    if(gameObject.transform.GetChild(i).tag != "Capsula"){
                        Debug.Log(gameObject.transform.GetChild(i).tag + " desactivada");
                        gameObject.transform.GetChild(i).gameObject.SetActive(false); //Se desactivan todos los componentes hijos de los jugadores nuevos para que no se mezclen con el actual
                    } 
        }
    }


    void desactivar(){
        //Debug.Log("SOY YOOOOOO");
                for (int i = 0; i < gameObject.transform.childCount; i++)
                {
                    gameObject.transform.GetChild(i).gameObject.SetActive(true); //Se activan las componentes únicas del jugador entrante
                    if(gameObject.transform.GetChild(i).tag == "MainCameraVR"){
                        Debug.Log(gameObject.transform.GetChild(i).tag + " desactivada");
                        gameObject.transform.GetChild(i).gameObject.SetActive(false); //Se desactivan todos los componentes hijos de los jugadores nuevos para que no se mezclen con el actual
                    }
                }
    }

}
    