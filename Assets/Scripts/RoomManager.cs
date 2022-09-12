using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System.IO;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;
    public GameObject hunterPrefab;
    public GameObject QuirquinchoManager;
    public GameObject prefabMadriguera;

    public static RoomManager Instance;
    public GameObject[] cameras;
    public int total = 0;
    private bool wait = true;
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
        if(scene.buildIndex == 1) //Número de escena asiciada al juego que queremos cargar, y aquí es donde instanciamos el Prefab del PlayerManager
        {
            wait = false;
            //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerManager"), Vector3.zero, (Quaternion.identity));
            //PhotonNetwork.Instantiate("PlayerManager", Vector3.zero, (Quaternion.identity));
            GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, playerPrefab.transform.position, Quaternion.identity);
            GameObject quirquincho = PhotonNetwork.Instantiate(QuirquinchoManager.name, Vector3.zero, Quaternion.identity);
            
            if (PhotonNetwork.IsMasterClient){
                StartCoroutine(HunterSpawn());
            }
            
        }
    }

    IEnumerator HunterSpawn()
    {
        yield return new WaitForSeconds(2);
        GameObject enemy = PhotonNetwork.Instantiate(hunterPrefab.name, new Vector3(Random.Range(-115, -110), 116, 513), Quaternion.identity);
        GameObject madriguera = PhotonNetwork.Instantiate(prefabMadriguera.name, playerPrefab.transform.position, Quaternion.identity);
    }

    /*public void ActualizarContador(int t)
    {
        total += t;
        Debug.Log("El total de la sesión es: " + total);
        cameras = GameObject.FindGameObjectsWithTag("MainCamera");
        foreach(GameObject p in cameras){
            p.GetComponent<AppleCounter>().InHomeForAll(total);
        }


    }*/


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
        StartCoroutine(ActualizarContador(1));
    }

    IEnumerator ActualizarContador(int t)
    {
        wait = true;
        yield return new WaitForSeconds(2);
        total += t;
        Debug.Log("El total de la sesión es: " + total);
        cameras = GameObject.FindGameObjectsWithTag("Jugador");
        
        foreach(GameObject p in cameras){
            //Debug.Log(cameras.Length);
            //Debug.Log("Hola soy un jugador");
            p.GetComponent<CameraCont>().ContadorTotal(t);
            //p.GetComponent<AppleCounter>().InHomeForAll(total);
        }
        wait = false;


    }
}
