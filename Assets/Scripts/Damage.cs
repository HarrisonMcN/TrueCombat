using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public PlayerMovement playerMovement;
    public float damageAmount;
    public GameObject hitBox;

    private void OnTriggerEnter(Collider other)
    {

        if(hitBox.activeSelf && !playerMovement.blocking)
        {
            playerHealth.TakeDamage(damageAmount);
        }

        if (hitBox.activeSelf && playerMovement.blocking)
        {
            playerHealth.TakeDamage(damageAmount / 2f);
        }




    }

}
