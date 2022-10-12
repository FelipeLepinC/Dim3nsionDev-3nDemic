using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBarVR : MonoBehaviour
{

    Slider slider;
    public GameObject target;
    public BarType barType;

    void Start()
    {
        slider = GetComponent<Slider>();

        if (transform.parent.gameObject.tag == "Player")
        {
            target = transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.gameObject;
        }
        else
        {
            target = transform.parent.transform.parent.gameObject;
        }
        switch (barType)
        {
            case BarType.health:
                slider.maxValue = target.GetComponent<Health>().HealthPoints;
                break;
            case BarType.energy:
                slider.maxValue = Disparar.COOLDOWN;
                break;
        }
    }

    void Update()
    {
        switch (barType)
        {
            case BarType.health:
                slider.value = target.GetComponent<Health>().HealthPoints;
                break;
            case BarType.energy:
                slider.value = target.GetComponent<Disparar>().cooldown_saliva;
                break;
        }
    }
}

