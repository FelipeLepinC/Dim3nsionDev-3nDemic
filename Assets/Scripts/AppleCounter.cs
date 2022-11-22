using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppleCounter : MonoBehaviour
{
    public Text PersonalCounter;
    public Text TotalCounter;
    public int counter;
    public int total;
    public Image alert;
    public GameObject Sonido;
    public Text entregado;
    public int actual;
    public Image panel;
    private GameObject gameManager;
    private GameObject roomManager;
    private GameObject[] cameras;
    public GameObject cuenta;
    //public FirstPersonController character;
    //public FirstPersonController controles;
    //private float nextActionTime = 0.0f;
    //public float period = 0.1f;
    //private Rigidbody2D Rigidbody2D;

    

    IEnumerator DoCheck() {
     for(;;) {
         // execute block of code here
         yield return new WaitForSeconds(.1f);
         counter += 1;
         PersonalCounter.text = "" + (int)counter;
     }
    }

    IEnumerator ApplesInHome(int apples){
        entregado.text = "¡Has depositado " + (int)apples + " manzanas en la madriguera!";
        entregado.enabled = true;
        panel.enabled = true;
        yield return new WaitForSeconds(4);
        entregado.enabled = false;
        panel.enabled = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        //PersonalCounter = GetComponent<Text>();
        //Rigidbody2D = GetComponent<Rigidbody2D>();
        counter = 0;
        total = 0;
        PersonalCounter.text = "0";
        TotalCounter.text = "0";
        alert.enabled = false;
        entregado.enabled = false;
        panel.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (counter == 5){
            alert.enabled = false;
        }
        TotalCounter.text = "" + (int)cuenta.gameObject.GetComponent<CameraCont>().contador;
        PersonalCounter.text = "" + (int)cuenta.gameObject.GetComponent<CameraCont>().counter;
        //PersonalCounter.text = "" + (int)counter;
        //roomManager = GameObject.FindWithTag("RoomManager");
        //TotalCounter.text = "" + (int)roomManager.gameObject.GetComponent<RoomManager>().total;
    //StartCoroutine("DoCheck");
    }

    public void Boost(){
        if(counter >=10){
            counter -= 10;
            PersonalCounter.text = "" + (int)counter;
            Debug.Log("Restado");
        }else{
            Debug.Log("No tienes suficiente comida");
        }
    }

    public bool Boost2(){
        if(counter >=10){
            counter -= 10;
            PersonalCounter.text = "" + (int)counter;
            Debug.Log("Restado");
            return true;
        }else{
            Debug.Log("No tienes suficiente comida");
            return false;
        }
    }

    public void persued(){
        alert.enabled = true;
    }

    public void not_persued(){
        alert.enabled = false;
    }

    public void Apple(){
        counter += 1;
        PersonalCounter.text = "" + (int)counter;
        //Instantiate(Sonido); //ASIGNAR SONIDO
    }

    public int InHome(){
        
        actual = counter;
        if (actual > 0){
            Debug.Log(actual);
            //gameManager = GameObject.FindWithTag("GameManager");
            //gameManager.GetComponent<QuirquinchoManager>().ActualizarContador(actual);
            roomManager = GameObject.FindWithTag("RoomManager");
            roomManager.GetComponent<RoomManager>().Llamar();
            int t = total + counter;
            cameras = GameObject.FindGameObjectsWithTag("MainCamera");
            foreach(GameObject p in cameras){
                Debug.Log("Hola soy un jugador");
                p.GetComponent<AppleCounter>().InHomeForAll(t);
            }
            //gameManager.GetComponent<RoomManager>().ActualizarContador(actual);
            //StartCoroutine(ApplesInHome(actual)); //Esto sirve para la alerta de interfaz creada en Testing
            Debug.Log("Hola");
        }
        //total += counter;
        counter = 0;
        PersonalCounter.text = "" + (int)counter;
        //TotalCounter.text = "" + (int)total;
        return total;
    }

    public void InHomeForAll(int t){
        //actual = counter;
        //total += t;
        //counter = 0;
        //PersonalCounter.text = "" + (int)counter;
        //TotalCounter.text = "" + (int)total;
        Debug.Log("El numero recibido por manager es : " + t);
        total = t;
        TotalCounter.text = "" + (int)total;
        return;

    }

    public void Reset()
    {
        counter = 0;
        PersonalCounter.text = "" + (int)counter;
        TotalCounter.text = "" + (int)total;
    }
}
