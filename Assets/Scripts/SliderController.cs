using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Stamina stamina;
    public PlayerHealth playerHealth;

    public bool currentStamina;
    public bool currentHealth;
    public bool heals;



    public Slider slider;

    private void Update()
    {
        if (currentStamina == true)
        {
            currentHealth = false;
            slider.value = stamina.currentStamina;
        }

        if (currentHealth == true)
        {
            currentStamina = false;
            slider.value = playerHealth.currentHealth;
        }

        
    }
}
