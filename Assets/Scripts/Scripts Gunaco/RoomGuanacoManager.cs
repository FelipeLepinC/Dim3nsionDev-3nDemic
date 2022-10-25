using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System.IO;

public class RoomGuanacoManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public GameObject TortugaManager;
    public GameObject trampaPrefab;

    public static RoomGuanacoManager Instance;
    public GameObject[] cameras;
    private GameObject[] plyr;
    public int total = 0;
    private bool wait = true;
    private int awa = 0;


    public GameObject[] enemigos;
    public int numeroDeEnemigos = 5;


    // Start is called before the first frame update
    void Start()
    {
        if(Instance) //verifica si ya existe otro RoomManager
        {
            Destroy(gameObject); //si hay solo 1, lo destruye
            return;
        }
        DontDestroyOnLoad(gameObject); //No destruir si soy el único RoomManager
        Instance = this; //Yo soy RoomManager
    }

    public override void OnEnable() {
        base.OnEnable();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public override void OnDisable() {
        base.OnDisable();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if(scene.buildIndex == 4 && awa == 0) //Número de escena asiciada al juego que queremos cargar, y aquí es donde instanciamos el Prefab del PlayerManager
        {
            Debug.Log("Se spawneará un jugador");
            awa = 1; // Impide que se spawneen 2 tortugas por jugador.
            wait = false;
            GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, playerPrefab.transform.position, Quaternion.identity);          
            if (PhotonNetwork.IsMasterClient){
                StartCoroutine(SpawnItems());
                StartCoroutine(GenerateNewEnemy());
            }
            
        }
    }

    IEnumerator SpawnItems()
    {
        yield return new WaitForSeconds(1);
        GameObject quirquincho = PhotonNetwork.Instantiate(TortugaManager.name, Vector3.zero, Quaternion.identity);
    }

    IEnumerator GenerateNewEnemy(){
        Vector3 portal = new Vector3(300.0f,34.126f,323.74f);
        // GameObject enemy = PhotonNetwork.Instantiate(enemyPrefab.name, portal, Quaternion.identity);
        // yield return new WaitForSeconds(Random.Range(10,20));
        // alerta.SetActive(true);

        for(int i=0; i < numeroDeEnemigos; i++){
            GameObject enemy = PhotonNetwork.Instantiate(enemyPrefab.name, portal, Quaternion.identity);
            enemy.AddComponent<Enemy>();
            yield return new WaitForSeconds(Random.Range(10,20));
            // alerta.SetActive(true);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (wait == false){
            StartCoroutine(ActualizarContador(5));
        }
        
    }

    public void Llamar()
    {
        Debug.Log("Alooo");
        
        
        plyr = GameObject.FindGameObjectsWithTag("MainCamera");
        foreach(GameObject p in plyr){
            Debug.Log("Tengo " + p.GetComponent<AppleCounter>().counter +" manzanas");
            StartCoroutine(ActualizarContador2(p.GetComponent<AppleCounter>().counter));
            p.GetComponent<AppleCounter>().counter = 0;
        }
        
        
    }

    IEnumerator ActualizarContador(int t)
    {
        wait = true;
        yield return new WaitForSeconds(2);
        
        //Debug.Log("El total de la sesión es: " + total);
        
        cameras = GameObject.FindGameObjectsWithTag("Jugador");
        

        //total += t;
        
        foreach(GameObject p in cameras){
            //Debug.Log(cameras.Length);
            //Debug.Log("Hola soy un jugador que va a jugar");
            
            //p.GetComponent<AppleCounter>().InHomeForAll(total);

            //Debug.Log("Toy jugando");
            //p.GetComponent<CameraCont>().ContadorTotal(t);
        }
        wait = false;
    }

    IEnumerator ActualizarContador2(int t)
    {
        wait = true;
        yield return new WaitForSeconds(2);
        total += t;
        //Debug.Log("El total de la sesión es: " + total);
        cameras = GameObject.FindGameObjectsWithTag("Jugador");
        
        foreach(GameObject p in cameras){
            //Debug.Log(cameras.Length);
            Debug.Log("Hola soy un jugador que va a jugar");
            p.GetComponent<CameraCont>().ContadorTotal(t);
            //p.GetComponent<AppleCounter>().InHomeForAll(total);
        }
        wait = false;
    }

    public void EntregarManzanas(){
        Debug.Log("VAMOS A ENTREGAR MANZANAS");
        cameras = GameObject.FindGameObjectsWithTag("Jugador");
        foreach(GameObject p in cameras){
            //Debug.Log(cameras.Length);
            Debug.Log("Hola soy un jugador que va a jugar");
            p.GetComponent<CameraCont>().RepartirManzanas();
            //p.GetComponent<AppleCounter>().InHomeForAll(total);
        }
    }
}
