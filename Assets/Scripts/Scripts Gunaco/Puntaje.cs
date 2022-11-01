using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Puntaje : MonoBehaviour
{
    public int puntos = 0;
    TextMeshProUGUI puntajeGuanaco;
    public bool tutorial = false;

    private void Start(){
        puntajeGuanaco = GameObject.Find("Puntaje").GetComponent<TextMeshProUGUI>();
    }

    private void Update(){
        puntajeGuanaco.text = puntos.ToString();
    }

    public void SumarPuntos(int cuantos){
        puntos += cuantos;
    }
}
