using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public int healAmount;

    public SliderController sliderController;

    public KeyCode healKey = KeyCode.Q;

    public Slider slider;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if(currentHealth <= 0)
        {
            Debug.Log("Is Dead");
        }
    }

    private void Update()
    {
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (Input.GetKeyDown(healKey) && sliderController.heals == true && slider.value > 0)
        {
            currentHealth += healAmount;

            slider.value -= 1;
        }
    }
}
