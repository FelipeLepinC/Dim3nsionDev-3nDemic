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
    public GameObject GuanacoManager;
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
        if(SceneManager.sceneCount == 1)
        {
            base.OnEnable();
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
    }

    public override void OnDisable() {
        base.OnDisable();
        SceneManager.sceneLoaded -= OnSceneLoaded;
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
                //StartCoroutine(SpawnItems());
                GameObject quirquincho = PhotonNetwork.Instantiate(GuanacoManager.name, Vector3.zero, Quaternion.identity);
            }
            
        }
    }

    IEnumerator SpawnItems()
    {
        yield return new WaitForSeconds(3);
        GameObject quirquincho = PhotonNetwork.Instantiate(GuanacoManager.name, Vector3.zero, Quaternion.identity);
        //this.photonView.RPC("HabilitarTiempo", RpcTarget.AllBuffered, quirquincho);
        //quirquincho.GetComponent<Tiempo>().enabled = true;
    }

    //IEnumerator GenerateNewEnemy(){
    //    Vector3 portal = new Vector3(300.0f,34.126f,323.74f);
    //    // GameObject enemy = PhotonNetwork.Instantiate(enemyPrefab.name, portal, Quaternion.identity);
    //    // yield return new WaitForSeconds(Random.Range(10,20));
    //    // alerta.SetActive(true);

    //    for(int i=0; i < numeroDeEnemigos; i++){
    //        GameObject enemy = PhotonNetwork.Instantiate(enemyPrefab.name, portal, Quaternion.identity);
    //        // enemy.AddComponent<Enemy>();
    //        yield return new WaitForSeconds(Random.Range(10,20));
    //        // alerta.SetActive(true);
    //    }
    //}

    [PunRPC]
    void HabilitarTiempo(GameObject tiempo){
        tiempo.GetComponent<Tiempo>().enabled = true;
    }
}
