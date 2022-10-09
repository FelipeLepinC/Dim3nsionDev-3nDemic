using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectarPlayer : MonoBehaviour
{
    Ray ray;
    RaycastHit raycastHit;
    GameObject[] enemies;
    //Text textUI;
    // Start is called before the first frame update
    void Start()
    {
        //textUI = GameObject.FindObjectOfType<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        /*ray = new Ray(transform.position, transform.forward);
        if(Physics.Raycast(ray, out raycastHit) && raycastHit.collider.gameObject.tag == "Atrapado"){
            Debug.Log(raycastHit.collider.gameObject.tag + " Detectado");
        }*/
        enemies = GameObject.FindGameObjectsWithTag("Atrapado");
        foreach (GameObject enemy in enemies)
        Debug.Log(enemies.Length);
        {
            Debug.Log(enemies.Length);
            Debug.Log("Hay un aliado cerca");
        }
    }
}
