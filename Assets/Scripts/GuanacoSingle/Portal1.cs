using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Portal1 : MonoBehaviour
{

    public GameObject[] enemigos;
    public int numeroDeEnemigos = 5;
    GameObject alerta;

    // Start is called before the first frame update
    void Start()
    {
        alerta = GameObject.FindWithTag("punto");
        StartCoroutine("GenerateNewEnemy");
    }

    IEnumerator GenerateNewEnemy(){
        for(int i=0; i < numeroDeEnemigos; i++){
            GameObject enemy_list = enemigos[Random.Range(0, enemigos.Length)];
            GameObject enemy = Instantiate(enemy_list, transform);
            enemy.AddComponent<Enemy1>();
            yield return new WaitForSeconds(Random.Range(10,20));
            alerta.SetActive(true);
        }
    }

}
