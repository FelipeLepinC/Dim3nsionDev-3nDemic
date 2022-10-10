using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MostrarKeyboard : MonoBehaviour
{
    // Start is called before the first frame update
    private TouchScreenKeyboard keyboard;

    public void OpenKeyboard()
    {
        TouchScreenKeyboard.Open("");
    }
}
