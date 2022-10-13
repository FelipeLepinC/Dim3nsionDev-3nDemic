using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;

public class Cazador : MonoBehaviour
{
    // Variables generales
    public float movementSpeed = 3f;
    public float rotationSpeed = 100f;

    // Errante
    private bool isWandering = false;
    private bool isRotationLeft = false;
    private bool isRotationRight = false;
    private bool isWalking = false;

    // Perseguimiento
    public Vector3 posicionPerseguido;
    public Vector3 posicionPerseguidor;
    public Vector3 direccionPersecucion;
    //public GameObject perseguido;
    //public AppleCounter interfaz;
    //public TimeController tiempo;
    private TimeController tiempo;
    public FieldOfView campoVision;

    Rigidbody rb;

    // Perseguimiento V2
    //public Transform target;
    private Transform target;
    private GameObject perseguido;
    NavMeshAgent nav;
    private bool visto = false;
    private bool perdido;
    private bool trapped;
    private GameObject[] jugadores; 
    private GameObject[] jugadoras; 

    // Animaciones
    Animator animator;

    // Reset
    //public GameObject madriguera;
    //public CharacterController controller;
    private CharacterController controller;
    //public AppleCounter ui_contador;
    public Vector3 pos;
    private AppleCounter ui_contador;
    private AppleCounter interfaz;
    private int contadores = 1;
    private int mayor;
    private int mayor2;

    // Start is called before the first frame update
    void Awake()
    {
        
        nav = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        perdido = true;
        campoVision.GetComponent<FieldOfView>().minimo();
        trapped = false;
        jugadores = GameObject.FindGameObjectsWithTag("Player1");
        jugadoras = GameObject.FindGameObjectsWithTag("Jugador");
        perseguido= GameObject.FindWithTag("Player1");
        controller = GameObject.FindWithTag("Player1").GetComponent<CharacterController>();
        interfaz = GameObject.FindWithTag("MainCamera").GetComponent<AppleCounter>();
        ui_contador = GameObject.FindWithTag("MainCamera").GetComponent<AppleCounter>();
        tiempo = GameObject.FindWithTag("PanelTiempo").GetComponent<TimeController>();
        //if(PhotonNetwork.isMasterClient){
        //    jugadores = GameObject.FindGameObjectsWithTag("Player1");
        //    perseguido= GameObject.FindWithTag("Player1");
        //    controller = GameObject.FindWithTag("Player1").GetComponent<CharacterController>();
        //    interfaz = GameObject.FindWithTag("MainCamera").GetComponent<AppleCounter>();
         //   ui_contador = GameObject.FindWithTag("MainCamera").GetComponent<AppleCounter>();
        //    tiempo = GameObject.FindWithTag("PanelTiempo").GetComponent<TimeController>();
        //}
        Debug.Log(jugadoras.Length);
        foreach(GameObject p in jugadoras){
                //p.GetComponent<CameraCont>().ContadorTotal();
                //Debug.Log("Hola soy un jugador");
                //p.GetComponent<AppleCounter>().InHomeForAll(t);
            }
    }

    
    IEnumerator verificar(){
        if (contadores == 1){
            //Debug.Log("Cazador entra a verificar");
            contadores = 2;
            mayor = 0;
            mayor2 = 0;
            foreach(GameObject p in jugadoras){
                //Debug.Log("Jugador detectado por el cazador, contador es: " + p.GetComponent<CameraCont>().contador);
                if ( p.GetComponent<CameraCont>().contador > mayor){
                    mayor = p.GetComponent<CameraCont>().contador;
                }
                if ( p.GetComponent<CameraCont>().counter > mayor2){
                    mayor2 = p.GetComponent<CameraCont>().counter;
                }
                
            }
            //Debug.Log("El mayor de todos es: " + mayor);
            
            foreach(GameObject p in jugadoras){
                p.GetComponent<CameraCont>().contador = mayor;
                p.GetComponent<CameraCont>().contador = mayor;
                p.GetComponent<CameraCont>().ganador = mayor2;
                //Debug.Log("Jugador detectado por el cazador, contador actualizado es: " + p.GetComponent<CameraCont>().contador);
                
            }
            yield return new WaitForSeconds(1);
            contadores = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(verificar());
        Debug.Log(campoVision.GetComponent<FieldOfView>().visibleTargets.Count);
        if (campoVision.GetComponent<FieldOfView>().visibleTargets.Count == 0)
        {
            if (visto == true && perdido == false){
                //nav.ResetPath();
                StartCoroutine(perdiendo());
            }
            if (perdido == true){
                trapped = false;
                visto = false;
                interfaz.GetComponent<AppleCounter>().not_persued();
                
                if (isWandering == false)
                {
                    
                    StartCoroutine(Wander());
                }
                if (isRotationRight == true)
                {
                    rb.velocity = new Vector3(0f, 0f, 0f);
                    transform.Rotate(transform.up * Time.deltaTime * rotationSpeed);
                    
                }
                if (isRotationLeft == true)
                {
                    rb.velocity = new Vector3(0f, 0f, 0f);
                    transform.Rotate(transform.up * Time.deltaTime * -rotationSpeed);
                }
                if (isWalking == true)
                {
                    rb.AddForce(transform.forward * movementSpeed);
                    animator.SetBool("isRunning", true);
                }
                if (isWalking == false)
                {
                    animator.SetBool("isRunning", false);
                }
            }
            
        }
        else if (trapped == false)
        {
            perdido = false;
            if (visto == false){
                //rb.AddForce(-(transform.forward * movementSpeed));
                rb.velocity = new Vector3(0f, 0f, 0f);
            }
            visto = true;
            interfaz.GetComponent<AppleCounter>().persued();
            //ProcessPosition();
            perseguir();
            //MoveToPerseguido();
        }
    }

    IEnumerator perdiendo(){
       
        yield return new WaitForSeconds(1);
        //Debug.Log(perdido);
        perseguir();
        while(perdido == false){
            yield return new WaitForSeconds(4);
            perdido = true;
            campoVision.GetComponent<FieldOfView>().minimo();
        }
        rb.velocity = new Vector3(0f, 0f, 0f);
        nav.ResetPath();
        
    }
    // Modo errante
    IEnumerator Wander()
    {
        int rotationTime = Random.Range(1, 3);
        int rotateWait = Random.Range(1, 3);
        int rotateDirection = Random.Range(1, 3);
        int walkWait = Random.Range(1, 3);
        int walkTime = Random.Range(1, 3);

        isWandering = true;
        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;
        yield return new WaitForSeconds(rotateWait);
        if (rotateDirection == 1 || rotateDirection == 3) 
        {
            isRotationLeft = true;
            animator.SetBool("isRotatingLeft", true);
            yield return new WaitForSeconds(rotationTime);
            animator.SetBool("isRotatingLeft", false);
            isRotationLeft = false;

        }
        if (rotateDirection == 2)
        {
            isRotationRight = true;
            animator.SetBool("isRotatingRight", true);
            yield return new WaitForSeconds(rotationTime);
            animator.SetBool("isRotatingRight", false);
            isRotationRight = false;

        }
        isWandering = false;
    }

    // Perseguir
    private void ProcessPosition()
    {
        posicionPerseguidor = this.gameObject.transform.position;
        posicionPerseguido = perseguido.transform.position;
        float direccionX = posicionPerseguido.x - posicionPerseguidor.x;
        float direccionY = posicionPerseguido.y - posicionPerseguidor.y;
        float direccionZ = posicionPerseguido.z - posicionPerseguidor.z;
        direccionPersecucion = new Vector3(direccionX, direccionY, direccionZ);
    }
    private void MoveToPerseguido()
    {
        animator.SetBool("isRunning", true);
        rb.AddForce(Vector3.Normalize(direccionPersecucion) * movementSpeed);
        transform.forward = Vector3.Normalize(direccionPersecucion);
    }

    void OnCollisionEnter(Collision player)
    {
        if (player.gameObject.layer == 8)
        {
            trapped = true;
            perdido = true;
            campoVision.GetComponent<FieldOfView>().minimo();
            nav.ResetPath();
            interfaz.GetComponent<AppleCounter>().not_persued();
            Debug.Log("Han pillado al jugador");
            tiempo.GetComponent<TimeController>().pillado();
            controller.enabled = false;
            perseguido.transform.position = new Vector3(-107.7f, 124.26f, 428.17f);
            controller.enabled = true;
            ui_contador.GetComponent<AppleCounter>().Reset();
        }
        if (player.gameObject.tag == "Apple"){
            Physics.IgnoreCollision(player.collider, GetComponent<Collider>());
        }
    }

    private void perseguir(){
        animator.SetBool("isRunning", true);
        //Debug.Log(jugadores.Length);
        // target= GameObject.FindWithTag("Player1").transform;
        campoVision.GetComponent<FieldOfView>().FindVisibleTargets();
        target = campoVision.GetComponent<FieldOfView>().targetMinimo;

        nav.SetDestination(target.position);
    }

    public void Saludar(){
        //Debug.Log("Maldito Armadillo");
    }

    public void ArmadilloOculto(){
        //yield return new WaitForSeconds(1);
        campoVision.GetComponent<FieldOfView>().enabled = false;
        interfaz.GetComponent<AppleCounter>().not_persued();
        //transform.localRotation *= Quaternion.Euler(0, 0, 180);
        
        //Debug.Log("Quirquincho se ha ocultado");
        Debug.Log(perdido);
        
        //perseguir();
        GetComponent<FieldOfView>().enabled = false;
        perdido = true;
        campoVision.GetComponent<FieldOfView>().minimo();
        transform.rotation = Quaternion.Inverse(transform.rotation);
        rb.velocity = new Vector3(0f, 0f, 0f);
        interfaz.GetComponent<AppleCounter>().not_persued();
        nav.ResetPath();
        
    }

    //public void 
}
