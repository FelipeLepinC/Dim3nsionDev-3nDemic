using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public CharacterController controller;
    public float velocidad = 10f;
    public AudioSource pasos;
    private bool Hactivo;
    private bool Vactivo;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movimiento = transform.right * x + transform.forward * z;
        controller.Move(movimiento * velocidad * Time.deltaTime);

        if(Input.GetButtonDown("Horizontal")){
            if(Vactivo==false){
                Hactivo = true;
                pasos.Play();
            }
        }

        if(Input.GetButtonDown("Vertical")){
            if(Hactivo==false){
                Vactivo = true;
                pasos.Play();
            }
        }

        if(Input.GetButtonUp("Horizontal")){
            Hactivo = false;
            if(Vactivo==false){
                pasos.Stop();
            }
        }

        if(Input.GetButtonUp("Vertical")){
            Vactivo = false;
            if(Hactivo==false){
                pasos.Stop();
            }
        }
    }
}
