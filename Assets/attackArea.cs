using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackArea : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
         health Health = other.GetComponent<health>();
        if (Health != null)
        {
            // Apply damage to the enemy
            Health.takeDamage(35);
        }
         // Calculate the direction away from the player
            Vector3 direction = other.transform.position - transform.position;
            direction.y = 1; // Optional: Keep the direction horizontal

            // Normalize the direction vector to get a unit vector
            direction.Normalize();

            // Apply knockback force to the enemy
            Rigidbody enemyRigidbody = other.GetComponent<Rigidbody>();
            if (enemyRigidbody != null)
            {
                enemyRigidbody.AddForce(direction * 100, ForceMode.Impulse);
            }
    
        if(other.CompareTag("enemy"))
        {
            Debug.Log("hit by player");
        }
    }
}
