using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraCont : MonoBehaviour
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
        //Debug.Log(counter);
        if (counter == 5){
            counter = 5;
        }

        else if(reset == 0 && reset == 0){
            camera.gameObject.GetComponent<AppleCounter1>().counter = 0;
             counter = 0;
             //reset = 1;
        }
        else if (reset == 1 ){
            counter = camera.gameObject.GetComponent<AppleCounter1>().counter; //se actualiza porque
        }

        if (view.IsMine) // Se restringe la activación de componentes solo para el jugador entrante
        {
            //Debug.Log("SOY YOOOOOO");
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

    public void ContadorTotal(int t)
    {
        //Debug.Log("Soy un jugador llamado por el cazador");
        //contador = t + contador;
        //contador = t + contador;
        Debug.Log(contador);
        if (view.IsMine){
            view.RPC("RPC_Function", RpcTarget.AllBuffered, t);
            //Debug.Log("AAAAAAA");
            //Debug.Log(RpcTarget.AllBuffered);
            //Debug.Log("AAAAAAA");
        }
        
        //camera.gameObject.GetComponent<AppleCounter>().InHomeForAll(contador);
    }

    public void RepartirManzanas(){
        int t = counter;
        //Debug.Log("Antes tenía tenemos:" + counter);
        //view.RPC("RPC_Function2", RpcTarget.AllBuffered, t);
        if (view.IsMine){
            reset = 0;
            //view.RPC("RPC_Function2", RpcTarget.AllBuffered, t);
        }
        view.RPC("RPC_Function2", RpcTarget.AllBuffered, ganador);
        //Debug.Log("Repartimos manzanas");
        //counter = 0;
        //Debug.Log("Ahora tenemos:" + counter);
        //Debug.Log("Finalmente: " + suma);
    }


    [PunRPC]
    void RPC_Function(int a)
    {
        contador = a + contador;
        //Debug.Log(contador);
        //Debug.Log("Soy la RPC Function");
        //camera.gameObject.GetComponent<AppleCounter>().InHomeForAll(contador);
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
        //Debug.Log(contador);
        //Debug.Log("Soy la RPC Function");
        //camera.gameObject.GetComponent<AppleCounter>().InHomeForAll(contador);
    }
}
