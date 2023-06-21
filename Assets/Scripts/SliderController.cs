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

    public Slider slider;

    private void Update()
    {
        if (currentStamina == true)
        {
            slider.value = stamina.currentStamina;
        }

        if (currentHealth == true)
        {
            slider.value = playerHealth.currentHealth;
        }
    }
}
