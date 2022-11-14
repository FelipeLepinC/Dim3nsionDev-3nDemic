using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuRanaBarMultiplayer : MonoBehaviour
{
    Slider slider;
    public GameObject target;
    HealthRanaMultiplayer vida;

    void Start()
    {
        slider = GetComponent<Slider>();
        if (target == null) target = transform.parent.transform.parent.transform.parent.gameObject;
        vida = target.GetComponent<HealthRanaMultiplayer>();
    }

    void Update()
    {
        slider.value = vida.HealthPoints/100.0f;
    }
}
