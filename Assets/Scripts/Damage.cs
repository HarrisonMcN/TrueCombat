using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int damageAmount;

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damageAmount);

        }

        
        
    }

}
