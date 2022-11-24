using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeController : MonoBehaviour
{
    [SerializeField] int min, seg;
    [SerializeField] Text tiempo, mensaje, puntaje, capturas, medalla, puntajeTexto, capturasTexto, medallaPNG;
    [SerializeField] Image bronze, silver, gold, marco;
    private float restante;
    private bool enMarcha;
    public Image panel;
    public CharacterController controller;
    public AppleCounter contadores;
    public bool finished;
    public Text button;
    public int capturado;
    private int puntos;
    private int calculo;
    private int medallaObtenida;
    public CameraCont cameraCont;
    // Start is called before the first frame update
    void Awake()
    {
        restante = (min * 60) + seg;
        enMarcha = true;
        mensaje.enabled = false;
        panel.enabled = false;
        puntaje.enabled = false;
        capturas.enabled = false;
        medalla.enabled = false;
        finished = false;
        button.enabled = false;
        puntajeTexto.enabled = false;
        capturasTexto.enabled = false;
        bronze.enabled = false;
        silver.enabled = false;
        gold.enabled = false;
        if (marco != null) marco.enabled = false;
        //puntajeTexto.text = "456";
        //capturasTexto.text = "456";
        capturado = 0;
        medallaObtenida = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (enMarcha){
            restante -= Time.deltaTime;
            if (restante < 1){
                enMarcha = false;
                mensaje.enabled = true;
                panel.enabled = true;
                if (marco != null)  marco.enabled = true;
                controller.enabled = false;
                StartCoroutine(puntuaciones());
                Debug.Log("Se acabó el tiempo");
            }
            int tempMin = Mathf.FloorToInt(restante / 60);
            int tempSeg = Mathf.FloorToInt(restante % 60);
            tiempo.text = string.Format("{00:00}:{01:00}", tempMin, tempSeg);
        }
        if (finished == true){
            enMarcha = false;
            mensaje.enabled = true;
            panel.enabled = true;
            if (marco != null) marco.enabled = true;
            controller.enabled = false;
            StartCoroutine(puntuaciones());
            Debug.Log("Se termino el juego");
            if (Input.GetKeyDown(KeyCode.Return)){
                SceneManager.LoadScene("MainMenu");
            }
        }
    }

    IEnumerator puntuaciones(){
        if (cameraCont != null) puntajeTexto.text = "" + (int)cameraCont.contador;
        else puntajeTexto.text = "" + contadores.counter;
        capturasTexto.text = "" + capturado;
        medallaObtenida = CalculoMedalla();
        yield return new WaitForSeconds(1);
        puntaje.enabled = true;
        puntajeTexto.enabled = true;
        yield return new WaitForSeconds(1);
        capturas.enabled = true;
        capturasTexto.enabled = true;
        yield return new WaitForSeconds(1);
        medalla.enabled = true;
        if (medallaObtenida == 3){
            bronze.enabled = true;
        }
        if (medallaObtenida == 2){
            silver.enabled = true;
        }
        if (medallaObtenida == 1){
            gold.enabled = true;
        }
        yield return new WaitForSeconds(1);
        finished = true;
        yield return new WaitForSeconds(1);
        //SceneManager.LoadScene("MainMenu");
        button.enabled = true;
        finished = true;
    }

    public void pillado(){
        capturado += 1;
    }

    private int CalculoMedalla(){
        //puntos = (int)contadores.GetComponent<AppleCounter>().total;
        if (cameraCont != null) puntos = cameraCont.contador;
        else puntos = contadores.counter;
        calculo = puntos - 5 * capturado;
        if (calculo >= 150){
            return 1;
        }
        if (calculo >= 100 && calculo < 150){
            return 2;
        }
        else{
            return 3;
        }
    }
}
