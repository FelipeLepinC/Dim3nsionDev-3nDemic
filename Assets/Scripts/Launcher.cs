using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

//Esto permite iniciar el modo multijugador

public class Launcher : MonoBehaviourPunCallbacks //Esta extensión de MonoBehavoiur nos da acceso a callbacks para creación de salas, errores, unirse a lobbys. etc.
{
    [SerializeField] TMP_InputField roomNameInputField;
    [SerializeField] TMP_Text errorText;
    [SerializeField] TMP_Text roomNameText;
    // Start is called before the first frame update

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;

    }

    public override void OnConnectedToMaster() //Callback llamado por Photon cuando conectamos exitosamente al servidor.
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        MenuManager.Instance.OpenMenu("title");
        Debug.Log("Hola a todos");
    }
    // Update is called once per frame
    public void CreateRoom()
    {
        if(string.IsNullOrEmpty(roomNameInputField.text))
        {
            return;
        }
        PhotonNetwork.CreateRoom(roomNameInputField.text);
        MenuManager.Instance.OpenMenu("loading");
        //OnJoinedRoom();

    }

    public override void OnJoinedRoom()
    {
        MenuManager.Instance.OpenMenu("room");  
        roomNameText.text = PhotonNetwork.CurrentRoom.Name;

    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        errorText.text = "Room Creation Failder" + message;
        MenuManager.Instance.OpenMenu("error");
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        MenuManager.Instance.OpenMenu("loading");
    }

    public override void OnLeftRoom()
    {
        MenuManager.Instance.OpenMenu("title");
    }
}
