using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] audios;

    private AudioSource controlAudio;

    public float volumen = 1.0f;
    private float tiempo_start = 0.0f;
    public float tiempo_end = 0.0f;

    private void Awake()
    {
        controlAudio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        InvokeRepeating("Musica", 1.0f, 6.0f);
    }

    void Musica()
    {
        if (GameObject.Find("RanaVR") == null)
        {
            int r = Random.Range(2, audios.Length - 1);
            controlAudio.PlayOneShot(audios[r], volumen);
        }
        else
        {
            controlAudio.PlayOneShot(audios[2], 0.1f);
        }
    }

    public void SeleccionAudio(int indice, float volumen)
    {
        Debug.Log($"Seleccionando audio con indice {indice}: {audios[indice].name}");
        controlAudio.PlayOneShot(audios[indice], volumen);
    }
}
