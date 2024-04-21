using System.Collections;
using UnityEngine;

public class StationaryObjectDash : MonoBehaviour
{
    public float dashDistance = 5f; // Distance to dash
    public float dashDuration = 0.2f; // Duration of the dash
    public float dashCooldown = 1f; // Cooldown between dashes
    public float dashInterval = 3f; // Interval between dashing attempts
    private bool canDash = true; // Flag to track if the object can dash

    void Start()
    {
        // Start the dash coroutine at regular intervals
        InvokeRepeating("DashTowardsPlayer", 0f, dashInterval);
    }

    void DashTowardsPlayer()
    {
        // Check if the object can dash
        if (canDash)
        {
            // Find the GameObject with the "Player" tag
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

            // If playerObject is found, calculate the direction to dash towards it
            if (playerObject != null)
            {
                Vector3 dashDirection = (playerObject.transform.position - transform.position).normalized;

                // Ignore the y component of the dash direction vector
                dashDirection.y = 0f;

                // Start the dash coroutine
                StartCoroutine(Dash(dashDirection));
            }
        }
    }

    IEnumerator Dash(Vector3 dashDirection)
    {
        // Disable dashing during the dash and set cooldown
        canDash = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;

        // Calculate the dash end position
        Vector3 dashEndPosition = transform.position + dashDirection * dashDistance;

        // Smoothly move the object to the dash end position over the dash duration
        float startTime = Time.time;
        while (Time.time < startTime + dashDuration)
        {
            float t = (Time.time - startTime) / dashDuration;
            transform.position = Vector3.Lerp(transform.position, dashEndPosition, t);
            yield return null;
        }
    }
}