using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereRayCast : MonoBehaviour
{
    public float radius = 1;
    public Color gizmoColor = Color.green;
    public bool showGizmos = true;
    //public AppleCounter ui_contador;
    private AppleCounter ui_contador;
    private RoomManager gameManager;
    private int total;
    private int candado = 1;
    GameObject[] cazadores;

    Collider[] Apples;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        StartCoroutine(IdentificarPlayers());
        //ui_contador = GameObject.FindWithTag("MainCamera").GetComponent<AppleCounter>();
    }

    IEnumerator IdentificarPlayers()
    {
        yield return new WaitForSeconds(2);
        ui_contador = GameObject.FindWithTag("MainCamera").GetComponent<AppleCounter>();
        gameManager = GameObject.FindWithTag("RoomManager").GetComponent<RoomManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    //PROBAR MAÑANA CON GGRPC
    void FixedUpdate(){
        Apples = Physics.OverlapSphere(this.transform.position, radius);
        foreach(Collider apple in Apples){
            if (apple.tag == "Jugador"){
                if (candado == 1){
                    candado = 0;
                    cazadores = GameObject.FindGameObjectsWithTag("Cazador");
                    //Debug.Log(cazadores.Length);
                    cazadores[0].GetComponent<Cazador>().Saludar();
                    cazadores[0].GetComponent<Cazador>().ArmadilloOculto();
                    //apple.tag = "Untagged";
                    gameManager.GetComponent<RoomManager>().Llamar();
                    StartCoroutine(abrirCandado(apple));
                }
                
                //total = ui_contador.GetComponent<AppleCounter>().InHome(); //ESTA DEBE ESTAR ACTIVADA
                //Debug.Log("Room Manager detecta que en total hay" + total + "manzanas");
                
            }
            
        }
    }

    IEnumerator abrirCandado(Collider apple){
        yield return new WaitForSeconds(5);
        candado = 1;
        //apple.tag = "Player1";
    }

    private void OnDrawGizmos() {
        if (showGizmos){
            Gizmos.color = gizmoColor;
            Gizmos.DrawSphere(transform.position, radius);
            
        }
        
    }
}
