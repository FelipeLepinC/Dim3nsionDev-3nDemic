using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppleCounter1 : MonoBehaviour
{
    public Text PersonalCounter;
    public Text TotalCounter;
    public int counter;
    public int total;
    public Image alert;
    public GameObject Sonido;
    public Text entregado;
    private int actual;
    public Image panel;
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

    public void persued(){
        alert.enabled = true;
    }

    public void not_persued(){
        alert.enabled = false;
    }

    public void Apple(){
        counter += 1;
        PersonalCounter.text = "" + (int)counter;
        Instantiate(Sonido);
    }

    public void InHome(){
        actual = counter;
        if (actual > 0){
            Debug.Log(actual);
            StartCoroutine(ApplesInHome(actual));
        }
        total += counter;
        counter = 0;
        PersonalCounter.text = "" + (int)counter;
        TotalCounter.text = "" + (int)total;

    }

    public void Reset()
    {
        counter = 0;
        PersonalCounter.text = "" + (int)counter;
        TotalCounter.text = "" + (int)total;
    }
}
