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
    public PlayerMovement playerMovement;

    public bool dodgeTick;
    public bool sprintTick;
    
    void Start()
    {
        currentStamina = maxStamina;

        dodgeTick = false;
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


        if (playerMovement.sprinting == false)
        {
            sprintTick = false;
        }


        if (playerMovement.sprinting == true)
        {
            currentStamina -= sprintCost * Time.deltaTime;
            dodgeTick = true;

        }

        if (playerMovement.sprinting == false)
        {
            currentStamina = Mathf.Round(currentStamina * 1.0f) * 1f;

        }
        
    }
}
