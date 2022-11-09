using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lengua : MonoBehaviour
{
    public float tiempoLengua = 0.5f;

    GameObject lengua;
    GameObject camara;
    GameObject cuerpo;
    bool lenguaActivada;
    float tiempoActualLengua;
    // Start is called before the first frame update
    void Start()
    {
        lengua = gameObject.transform.GetChild(4).gameObject;
        camara = gameObject.transform.GetChild(0).gameObject;
        cuerpo = gameObject.transform.GetChild(3).gameObject;
        lengua.SetActive(false);
        lenguaActivada = false;
        tiempoActualLengua = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!lenguaActivada)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                lenguaActivada = true;
                CalcularPosicionLengua();
                lengua.SetActive(true);
            }
        }
        else
        {
            tiempoActualLengua += Time.deltaTime;
            if (tiempoActualLengua > tiempoLengua)
            {
                lenguaActivada = false;
                lengua.SetActive(false);
                tiempoActualLengua = 0f;
            }
        }
    }

    void CalcularPosicionLengua()
    {
        Vector3 posicionLengua = cuerpo.transform.position + cuerpo.transform.forward*(-2);
        Quaternion rotacionLengua = camara.transform.rotation;
        lengua.transform.position = posicionLengua;
        lengua.transform.rotation = rotacionLengua;
    }
}
