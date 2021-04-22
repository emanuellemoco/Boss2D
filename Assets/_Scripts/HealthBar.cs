using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{    
    public Slider slider;
    public Gradient gradient; 
    public Image fill;
    private GameManager gm;


    public void Start()
    {
        gm = GameManager.GetInstance();

        slider.maxValue = gm.life;
        slider.value = gm.life;
    }

    public void Update ()
    {
        slider.value = gm.life;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }



}
