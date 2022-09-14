using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ComidaAleatoria : MonoBehaviour
{
    public GameObject Energia;

    int X = -5;
    int Z = 5;
    int Y = 12;

    // Start is called before the first frame update
    void Start()
    {
        Energia = GameObject.Find("Energia");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int cantidadEnergia = Energia.transform.childCount;
        int cantidadComida = 0;
        Transform energia_aux;
        for (int i = 0; i < cantidadEnergia; i++)
        {
            energia_aux = Energia.transform.GetChild(i);
            if (energia_aux.gameObject.tag == "Alimento")
            {
                cantidadComida++;
            }
        }
        if (cantidadComida < 5)
        {
            int deltaX = new System.Random().Next(-4, 4);
            int deltaZ = new System.Random().Next(-4, 4);
            GameObject nueva_comida = new GameObject(name = "Nueva Comida");
            nueva_comida.tag = "Alimento";
            //Transform transform = new Transform();
            nueva_comida.AddComponent<Transform>();
            nueva_comida.transform.position = new Vector3(X + deltaX, Y, Z + deltaZ);
            nueva_comida.transform.SetParent(Energia.transform);
        }
    }
}