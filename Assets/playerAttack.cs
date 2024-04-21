using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;

public class playerAttack : MonoBehaviour
{
    public GameObject attackArea;
    public float cooldownDuration = 10f; // Cooldown duration in seconds
    private bool isOnCooldown = false; // Flag to track if the spell is on cooldown
    private float cooldownTimer = 0f; // Timer to track the cooldown duration

   
    public float attackDuration = 1.0f;
    float attackTimer;

    void Start()
    {
        attackArea.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        // Update the cooldown timer if the spell is on cooldown
        if (isOnCooldown)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0)
            {
                isOnCooldown = false; // Reset the cooldown flag when cooldown is over
            }
        }
    
         if(attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
            if(attackTimer <= 0)
            {
                attackArea.SetActive(false);
                isOnCooldown = true;
            }
        }
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            if(isOnCooldown == false)
            {
            attackArea.SetActive(true);
            attackTimer = attackDuration;
            }
        }
    }
}
