using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class playerHealth : health
{
    public static playerHealth instance;

    public static UnityEvent healthChanged = new UnityEvent();
    public override void Start()
    {
        base.Start();
        instance = this;
        healthChanged.Invoke();
    }

    public override void takeDamage(int amount)
    {
        base.takeDamage(amount);
        healthChanged.Invoke();
    }
    // Update is called once per frame
    public override void healHealth(int amount)
    {
        base.healHealth(amount);
        healthChanged.Invoke();
    }
}