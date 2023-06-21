using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    public int maxStamina;
    public float currentStamina;

    public int jumpCost;
    public int dodgeCost;
    public float sprintCost;
    public float staminaRegen;
    public float staminaRegenTimer;
    public PlayerMovement playerMovement;

    public bool dodgeTick;
    public bool jumpTick;
    
    void Start()
    {
        currentStamina = maxStamina;

        dodgeTick = false;
        jumpTick = false;
    }

    
    void Update()
    {
        if (playerMovement.isDodging == false)
        {
            dodgeTick = false;
        }

        if (playerMovement.isDodging == true && !dodgeTick)
        {
            currentStamina -= dodgeCost;
            dodgeTick = true;

        }

        if (playerMovement.jumping == false)
        {
            jumpTick = false;
        }

        if (playerMovement.jumping == true && !jumpTick)
        {
            currentStamina -= jumpCost;
            jumpTick = true;
        }




        if (playerMovement.sprinting == true)
        {
            currentStamina -= sprintCost * Time.deltaTime;
           

        }

        //if (playerMovement.sprinting == false)
        //{
            //currentStamina = Mathf.Round(currentStamina * 1.0f) * 1f;

        //}

        if (playerMovement.blocking || playerMovement.isDodging || playerMovement.sprinting || !playerMovement.grounded)
        {
            staminaRegenTimer = 0;
        }
        else
        {
            staminaRegenTimer += Time.deltaTime;

            if (currentStamina < maxStamina && staminaRegenTimer > 1f)
            {
                currentStamina += staminaRegen * Time.deltaTime;
            }

        }

    }

   
}
