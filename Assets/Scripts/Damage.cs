using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int damageAmount;
    public GameObject hitBox;

    private void OnTriggerEnter(Collider other)
    {

        if(hitBox.activeSelf)
        {
            playerHealth.TakeDamage(damageAmount);
        }


        
        
    }

}
