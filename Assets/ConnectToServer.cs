using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(); //Primero nos conectamos al servidor de Photon Mediante función Start al comenzar
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(); // Una vez conectados, nos unimos a la Lobby
    }

    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene("Lobby"); //Cuando nos unimos a la Lobby, cargamos la escena de la Lobby
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
