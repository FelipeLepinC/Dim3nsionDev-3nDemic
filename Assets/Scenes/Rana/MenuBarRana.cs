using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBarRana : MonoBehaviour
{

    Slider slider;
    public GameObject target;
    HealthRana vida;

    void Start()
    {
        slider = GetComponent<Slider>();
        target = transform.parent.transform.parent.transform.parent.gameObject;
        vida = target.GetComponent<HealthRana>();
    }

    void Update()
    {
        slider.value = vida.HealthPoints/100.0f;
    }
}
