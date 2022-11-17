using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class GuanacosManager : MonoBehaviour
{
    public GameObject[] jugadores;
    public GameObject[] fantasmas;
    public int total;
    public int puntos = 0;
    int inicio;

    public int numeroDeEnemigos = 5;
    public GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateNewEnemy());
        Debug.Log("Hola soy el Guanacos Manager");
        this.GetComponent<Tiempo>().enabled = true;
        jugadores = GameObject.FindGameObjectsWithTag("Player");
        inicio = jugadores.Length;
    }

    // Update is called once per frame
    void Update()
    {
        jugadores = GameObject.FindGameObjectsWithTag("Player");
        Debug.Log(jugadores.Length);
        if (jugadores.Length == 0){
            Debug.Log("Perdieron :( el puntaje logrado fue: " + puntos);
            fantasmas = GameObject.FindGameObjectsWithTag("Ghost");
            foreach (GameObject f in fantasmas){
                //f.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                f.gameObject.transform.GetChild(0).GetChild(4).gameObject.GetComponent<TimeControllerGuanaco>().Listo();
            }
        }
    }

    public void ActualizarContador(int t)
    {
        total += t;
        Debug.Log("El total de la sesión es: " + total);
        jugadores = GameObject.FindGameObjectsWithTag("Jugador");
        foreach(GameObject p in jugadores){
            p.GetComponent<CameraCont>().ContadorTotal(5);
            Debug.Log("Hola soy un jugador");
            //p.GetComponent<AppleCounter>().InHomeForAll(total);
        }
    }

    public void SumarPuntos(){
        puntos = puntos + 1;
    }

    IEnumerator GenerateNewEnemy()
    {
        Vector3 portal = new Vector3(300.0f, 34.126f, 323.74f);
        // GameObject enemy = PhotonNetwork.Instantiate(enemyPrefab.name, portal, Quaternion.identity);
        // yield return new WaitForSeconds(Random.Range(10,20));
        // alerta.SetActive(true);

        for (int i = 0; i < numeroDeEnemigos; i++)
        {
            GameObject enemy = PhotonNetwork.Instantiate(enemyPrefab.name, portal, Quaternion.identity);
            // enemy.AddComponent<Enemy>();
            yield return new WaitForSeconds(Random.Range(10, 20));
            // alerta.SetActive(true);
        }
    }
}
