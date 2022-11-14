using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TerminarRana : MonoBehaviourPunCallbacks
{
    public GameObject panelTiempo;
    public TimeControllerRanaMultiplayer controller;
    PhotonView view;

    // Start is called before the first frame update
    private void Start() {
        view = GetComponent<PhotonView>();
        gameObject.GetComponent<FirstPersonMovement>().enabled = false;
        if(view.IsMine)
        {
            gameObject.GetComponent<FirstPersonMovement>().enabled = true;
        }
    }

    public void changeFinished()
    {
        controller = panelTiempo.GetComponent<TimeControllerRanaMultiplayer>();
        controller.finished = true;
    }
}
