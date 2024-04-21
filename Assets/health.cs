using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    // Start is called before the first frame update
    public virtual void  Start()
    {
        currentHealth = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void  takeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
    }

    public virtual void healHealth(int amount)
     {
         currentHealth += amount;
         if (currentHealth >= 100)
         {
               currentHealth = maxHealth;
         }

     }

}

