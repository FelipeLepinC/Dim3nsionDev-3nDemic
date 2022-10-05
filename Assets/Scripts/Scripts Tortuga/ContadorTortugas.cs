using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadorTortugas : MonoBehaviour
{
    public Text TortugaCounter;
    public GameObject PanelTiempo;
    private TimeControllerTortuga tiempo;
    private int maxNPC;
    public int rescatadas;
    // Update is called once per frame
    void Start()
    {
        GameObject NPCs = GameObject.Find("Tortugas NPC");
        maxNPC = NPCs.transform.childCount;
    }

    void Update()
    {
        GameObject NPCs = GameObject.Find("Tortugas NPC");
        int cantidadNPCs = NPCs.transform.childCount;
        TortugaCounter.text = "" + (int)cantidadNPCs;
        rescatadas = maxNPC - cantidadNPCs;
        if (cantidadNPCs == 0)
        {
            //terminar.finished = true;
            tiempo = PanelTiempo.GetComponent<TimeControllerTortuga>();
            tiempo.finished = true;
            // Terminar el juego
        }
    }
}
