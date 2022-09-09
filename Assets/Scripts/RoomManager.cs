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

    public static RoomManager Instance;
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
            //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerManager"), Vector3.zero, (Quaternion.identity));
            //PhotonNetwork.Instantiate("PlayerManager", Vector3.zero, (Quaternion.identity));
            GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, playerPrefab.transform.position, Quaternion.identity);
            StartCoroutine(HunterSpawn());
        }
    }

    IEnumerator HunterSpawn()
    {
        yield return new WaitForSeconds(3);
        GameObject enemy = PhotonNetwork.Instantiate(hunterPrefab.name, new Vector3(Random.Range(-115, -110), 116, 513), Quaternion.identity);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
