using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    Vector2 movementdDir;
    public float moveSpeed = 10;
    

    Rigidbody rb ;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementdDir = context.ReadValue < Vector2>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(movementdDir.x * moveSpeed, rb.velocity.y, movementdDir.y * moveSpeed);

    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
