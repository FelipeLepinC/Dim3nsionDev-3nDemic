using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class IniciarCamara : MonoBehaviour
{
    //MultigameObjectSinc
    PhotonView view;
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void activar()
    {
        Debug.Log("Script IniciarCamara leído");
        if (view.IsMine)
        {
            //Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), Input.GetAxisRaw("Up"));
            //transform.position += input.normalized * 6 * Time.deltaTime;
            Debug.Log("I AM THOU, THOU AM IIIII");
            if (gameObject.GetPhotonView().IsMine){
                Debug.Log("I AM THOU, THOU AM I");
                Debug.Log(gameObject.transform.childCount);
                for (int i = 0; i < gameObject.transform.childCount; i++)
                {
                    Debug.Log(gameObject.transform.GetChild(i).tag);
                    //transform.GetChild(i).gameObject.SetActive(true);
                    if (gameObject.transform.GetChild(i).tag == "MainCamera")
                    {
                        Debug.Log("yuju");
                        //gameObject.transform.GetChild(i).gameObject.SetActive(true);
                        
                    }
                }
            }
        }
    }
}
