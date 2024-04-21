using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBase : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public int damage = 10;

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerContacted(other.gameObject);
        }
    }

    public virtual void PlayerContacted(GameObject p)
    {
        Debug.Log("contact with the player");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
