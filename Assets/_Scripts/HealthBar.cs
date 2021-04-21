using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{    
    public Slider slider;
    public Gradient gradient; 
    public Image fill;
    public void SetMaxHealth (int health)
    {
        Debug.Log("SetMaxHealth");
        Debug.Log(health);
        Debug.Log("________");
        slider.maxValue = health;
        slider.value = health;

        //para ter cores
        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth (int health)
    {
        Debug.Log("SetHealth");
        Debug.Log(health);
        Debug.Log("________");
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }



}
