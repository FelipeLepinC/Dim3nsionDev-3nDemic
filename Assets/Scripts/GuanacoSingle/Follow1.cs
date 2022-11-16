using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow1 : MonoBehaviour
{
    public float speed = 5.0f;

    bool direccionEscapeLista = false;
    Vector3 direccionEscape;
    float deltaTime = 0.0f;
    const float segundosAlejandose = 1.5f;
    public bool derrotado = false;
    Transform destination;
    GameObject player;
    GameObject alerta;

    void Start()
    {
        alerta = GameObject.FindWithTag("punto");
        player = GameObject.FindWithTag("Player");
        destination = player.transform;
    }

    void Update()
    {
        if (!derrotado)
        {
            alerta.SetActive(true);
            float space = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, destination.position, space);

            Vector3 targetDirection = destination.position - transform.position;
            Vector3 newposition = Vector3.RotateTowards(transform.forward, targetDirection, space, 0);
            transform.rotation = Quaternion.LookRotation(newposition);
        }
        else
        {
            alerta.SetActive(false);
            deltaTime = deltaTime + Time.deltaTime;
            if (deltaTime > segundosAlejandose) Destroy(gameObject);
            else
            {
                float space = speed * Time.deltaTime;
                if (!direccionEscapeLista)
                {
                    direccionEscape = new Vector3(transform.forward.x * -1, 0, transform.forward.z * -1);
                    transform.rotation = Quaternion.LookRotation(direccionEscape);
                    direccionEscapeLista = true;
                }
                else
                {
                    // alejandose
                    transform.position = Vector3.MoveTowards(transform.position, transform.position + direccionEscape, space);
                }
            }
        }
    }
}
