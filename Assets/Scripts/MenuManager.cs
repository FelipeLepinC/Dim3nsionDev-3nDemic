using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Menu[] menus;
    public TMP_Text textoNombreSala;
    public static MenuManager Instance;

    void Awake() {
        Instance = this;
    }

    public void OpenMenu(string menuName)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].menuName == menuName)
            {
                //OpenMenu(menus[i]);
                menus[i].Open();
            }
            else if (menus[i].open)
            {
                CloseMenu(menus[i]);
            }
        }
    }

    public void OpenMenu(Menu menu)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].open)
            {
                CloseMenu(menus[i]);
            }
        }
        if (menu.menuName == "room")
        {
            string nombreSala = gameObject.GetComponent<RoomLauncher>().nombreSala;
            textoNombreSala.text = nombreSala;
        }
        menu.Open();
    }

    public void CloseMenu(Menu menu) {

        menu.Close();

    }
    public void SalirAlMuseo()
    {
        SceneManager.LoadScene("Museo VR");
    }
}
