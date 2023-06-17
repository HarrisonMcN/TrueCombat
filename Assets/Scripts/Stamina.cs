using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    public int maxStamina;
    public int currentStamina;

    public int jumpCost;
    public int dodgeCost;
    public int sprintCost;
    public PlayerMovement playerMovement;

    public bool dodgeTick;
    
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
    }
}
