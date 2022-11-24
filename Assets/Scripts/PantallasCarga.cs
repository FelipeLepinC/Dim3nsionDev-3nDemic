using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PantallasCarga : MonoBehaviour
{
    public GameObject[] pantallas;
    public int r;
    private float tiempo_start = 0.0f;
    public float tiempo_end = 5.0f;
    public string juego;
    // Start is called before the first frame update

    void Start(){
        r = Random.Range(0, pantallas.Length);
    }
    // Update is called once per frame
    void Update()
    {   
        pantallas[r].SetActive(true);
        tiempo_start += Time.deltaTime;
        if (tiempo_start >= tiempo_end){
            if(juego == "Guanaco"){
                SceneManager.LoadScene("JuegoGuanaco VR 1");
            }
            if(juego == "Tortuga"){
                SceneManager.LoadScene("JuegoTortuga VR");
            }
            if(juego == "Rana"){
                SceneManager.LoadScene("JuegoRanaVR");
            }
            if(juego == "Quirquincho"){
                SceneManager.LoadScene("Quirquincho VR");
            }
            if(juego == "TutorialGuanaco"){
                SceneManager.LoadScene("JuegoGuanaco VR Tutorial");
            }
            if(juego == "TutorialTortuga"){
                SceneManager.LoadScene("JuegoTortuga VR Tutorial");
            }
            if(juego == "TutorialRana"){
                SceneManager.LoadScene("JuegoRanaVR Tutorial");
            }
            if(juego == "TutorialQuirquincho"){
                SceneManager.LoadScene("Quirquincho VR Tutorial");
            }
        }

        
    }
}
