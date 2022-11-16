using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PantallasCarga : MonoBehaviour
{
    public GameObject[] pantallas;
    public int r = 0;
    private float tiempo_start = 0.0f;
    public float tiempo_end = 5.0f;
    public string juego;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        tiempo_start += Time.deltaTime;
        if (tiempo_start >= tiempo_end){
            pantallas[r].SetActive(false);
            r = Random.Range(0, pantallas.Length);
            pantallas[r].SetActive(true);
            tiempo_start = 0.0f;
        }

        if (OVRInput.Get(OVRInput.Button.One))
        {
            if(juego == "Guanaco"){
                SceneManager.LoadScene("JuegoGuanaco VR");
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
        }
    }
}
