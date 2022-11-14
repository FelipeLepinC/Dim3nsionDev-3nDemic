using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;


public class TimeControllerRanaMultiplayer : MonoBehaviourPunCallbacks
{
    [SerializeField] Text tiempo, mensaje, puntaje, rostizadas, medalla, puntajeTexto, rostizadasTexto, medallaPNG;
    [SerializeField] Image bronze, silver, gold;
    public float cronometroActual;
    private bool enMarcha;
    public Image panel;
    public FirstPersonMovement controller;
    public bool finished;
    public Text button;
    public Text cantJugadoresColisionandoObstaculoText;
    public int cantJugadoresColisionandoObstaculo;
    public int cantTotalJugadores;
    public int rostizado;
    private int puntos;
    private int calculo;
    private int medallaObtenida;


    // Start is called before the first frame update
    void Awake()
    {
        cronometroActual = 0;
        enMarcha = true;
        mensaje.enabled = false;
        panel.enabled = false;
        puntaje.enabled = false;
        rostizadas.enabled = false;
        medalla.enabled = false;
        finished = false;
        button.enabled = false;
        puntajeTexto.enabled = false;
        rostizadasTexto.enabled = false;
        bronze.enabled = false;
        silver.enabled = false;
        gold.enabled = false;
        rostizado = 0;
        cantJugadoresColisionandoObstaculoText.enabled = false;
        // cantTotalJugadores = GameObject.Find("Jugadores").transform.childCount;
        // cantTotalJugadores = GameObject.Find("Rana_Multiplayer");
        cantTotalJugadores = PhotonNetwork.CurrentRoom.PlayerCount;
        // Debug.Log(cantTotalJugadores);
        cantJugadoresColisionandoObstaculo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (enMarcha)
        {
            cronometroActual += Time.deltaTime;
            int tempMin = Mathf.FloorToInt(cronometroActual / 60);
            int tempSeg = Mathf.FloorToInt(cronometroActual % 60);
            tiempo.text = string.Format("{00:00}:{01:00}", tempMin, tempSeg);
            if (tempMin >= 5) finished = true;
            cantJugadoresColisionandoObstaculoText.text = $"{cantJugadoresColisionandoObstaculo}/{cantTotalJugadores} Moviendo";
        }
        if (finished == true && enMarcha == true)
        {
            enMarcha = false;
            mensaje.enabled = true;
            panel.enabled = true;
            if (controller != null) controller.enabled = false;
            StartCoroutine(puntuaciones());
            Debug.Log("Termino la partida");
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }

    IEnumerator puntuaciones()
    {
        puntajeTexto.text = "" + (int)(cronometroActual / 60); ;
        //capturasTexto.text = "" + capturado;
        medallaObtenida = CalculoMedalla();
        yield return new WaitForSeconds(1);
        puntaje.enabled = true;
        puntajeTexto.enabled = true;
        yield return new WaitForSeconds(1);
        rostizadas.enabled = true;
        rostizadasTexto.enabled = true;
        yield return new WaitForSeconds(1);
        medalla.enabled = true;
        if (medallaObtenida == 3)
        {
            bronze.enabled = true;
        }
        if (medallaObtenida == 2)
        {
            silver.enabled = true;
        }
        if (medallaObtenida == 1)
        {
            gold.enabled = true;
        }
        yield return new WaitForSeconds(1);
        finished = true;
        yield return new WaitForSeconds(1);
        button.enabled = true;
        finished = true;
    }

    public void Rostizado()
    {
        rostizado += 1;
    }

    private int CalculoMedalla()
    {
        puntos = (int)(cronometroActual / 60);
        calculo = puntos + (int)rostizado;
        if (calculo <= 2)
        {
            return 1;
        }
        else if (calculo <= 4)
        {
            return 2;
        }
        else
        {
            return 3;
        }
    }
    public void JugadorColisionandoObstaculo()
    {
        cantJugadoresColisionandoObstaculo++;
        cantJugadoresColisionandoObstaculoText.enabled = true;
    }
    public void JugadorNoColisionandoObstaculo()
    {
        cantJugadoresColisionandoObstaculo--;
        cantJugadoresColisionandoObstaculoText.enabled = false;
    }
}

