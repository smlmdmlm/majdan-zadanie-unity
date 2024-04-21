using System.Collections;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashDistance = 5f; // Distance to dash
    public float dashDuration = 0.2f; // Duration of the dash
    public float dashCooldown = 1f; // Cooldown between dashes
    private bool canDash = true; // Flag to track if the player can dash
    private Vector3 dashDirection; // Direction of the dash
    private Rigidbody rb; // Reference to the player's Rigidbody component

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get input for dashing (e.g., pressing a specific button)
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            // Calculate the direction to dash based on the player's current velocity
            dashDirection = rb.velocity.normalized;

            // Start the dash coroutine
            StartCoroutine(Dash());
        }
    }

    IEnumerator Dash()
    {
        // Disable dashing during the dash and set cooldown
        canDash = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;

        // Calculate the dash end position
        Vector3 dashEndPosition = transform.position + dashDirection * dashDistance;

        // Smoothly move the player to the dash end position over the dash duration
        float startTime = Time.time;
        while (Time.time < startTime + dashDuration)
        {
            float t = (Time.time - startTime) / dashDuration;
            rb.MovePosition(Vector3.Lerp(transform.position, dashEndPosition, t));
            yield return null;
        }
    }
}
