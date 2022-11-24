using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BarType1 {
    health,
    energy
}
public class MenuBar1 : MonoBehaviour
{

    Slider slider;
    public GameObject target;
    public BarType1 barType;

    void Start()
    {
        slider = GetComponent<Slider>();

        switch(barType){
            case BarType1.health:
                slider.maxValue = target.GetComponent<Health1>().HealthPoints;
                break;
            case BarType1.energy:
                slider.maxValue = Disparar1.COOLDOWN;
                break;
        }
    }

    void Update()
    {
        switch(barType){
            case BarType1.health:
                slider.value = target.GetComponent<Health1>().HealthPoints;
                break;
            case BarType1.energy:
                slider.value = target.GetComponent<Disparar1>().cooldown_saliva;
                break;
        }
    }
}
