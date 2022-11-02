using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class Puntaje : MonoBehaviour
{
    public int puntos = 0;
    TextMeshProUGUI puntajeGuanaco;

    private void Start(){
        puntajeGuanaco = GameObject.Find("Puntaje").GetComponent<TextMeshProUGUI>();
    }

    private void Update(){
        puntos = GameObject.FindWithTag("GameManager").GetComponent<GuanacosManager>().puntos;
        puntajeGuanaco.text = puntos.ToString();
        
    }

    public void SumarPuntos(int cuantos){
        puntos += cuantos;
    }
}
