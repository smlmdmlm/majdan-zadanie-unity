using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class delayedHeal : enemyBase

{
    public float explosionTime = 1.5f;

    float timer = 0f;

    GameObject player;

    // Start is called before the first frame update
    
    void Update()
    {
        if(timer>0)
        {
            timer -= Time.deltaTime;
            if(timer <=0)
            {
                //explosion

                health hp = player.GetComponent<health>();
                hp.healHealth(30);
                Destroy(gameObject);
            }
        }
    }
    
    public override void PlayerContacted(GameObject p)
    {
        timer = explosionTime;
        player = p;
    }
}

