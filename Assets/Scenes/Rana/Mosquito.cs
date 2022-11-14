using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mosquito : MonoBehaviour
{
    const float vidaAgregada = 10f;

    [SerializeField] Vector3 movemnetVector = new Vector3(0f, 0f, 0f);
    float movementFactor;

    [SerializeField] float period = 4f; // time for 1 cycle (4 secs)

    Vector3 startingpos;

    void Start()
    {
        startingpos = transform.position;
    }

    void Update()
    {

        if (period <= 0f) { return; }
        float cycles = Time.time / period;

        const float tau = Mathf.PI * 2;
        float rawSineWave = Mathf.Sin(cycles * tau);

        movementFactor = rawSineWave / 2f + 0.5f;

        Vector3 offset = movemnetVector * movementFactor;
        transform.position = startingpos + offset;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Lengua")
        {
            // soundManager.SeleccionAudio(0, 1.0f);
            HealthRana vidaPlayer = collision.gameObject.GetComponent<HealthRana>();
            vidaPlayer.GanarVida(vidaAgregada);
            Destroy(gameObject);
        }
    }
}