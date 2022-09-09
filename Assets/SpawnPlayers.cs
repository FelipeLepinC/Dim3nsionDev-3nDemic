using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject giantApple;
    public GameObject hunterPrefab;
    
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;
    public float minZ;
    public float maxZ;


    private void Start() {
        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
        GameObject apple = PhotonNetwork.Instantiate(giantApple.name, new Vector3(Random.Range(-115, -110), 116, 513), Quaternion.identity);
        GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, playerPrefab.transform.position, Quaternion.identity);
        StartCoroutine(HunterSpawn());
        
        if(1 == 1){
            Debug.Log(":O");
        }
    }

    IEnumerator HunterSpawn(){
        yield return new WaitForSeconds(3);
        GameObject enemy = PhotonNetwork.Instantiate(hunterPrefab.name, new Vector3(Random.Range(-115, -110), 116, 513), Quaternion.identity);
    }
        
    


}
