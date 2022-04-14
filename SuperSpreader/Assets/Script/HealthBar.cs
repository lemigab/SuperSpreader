using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
   // public HealthColour hColor;
    public void setMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = 0;

    }
    public void setHealth(int health)
    {
        slider.value = health;
    }
     public void setMaxHealthFloat(float health)
    {
        slider.maxValue = health;
        slider.value = 0;

    }
    public void setHealthFloat(float health)
    {
        slider.value = health;
    }








 }
 
