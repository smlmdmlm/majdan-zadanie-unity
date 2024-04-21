using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemyAttack : enemyBase
{
    // Start is called before the first frame update
    public override void PlayerContacted(GameObject p)
    {
        health hp = p.GetComponent<health>();
        hp.takeDamage(30);
    }
}
