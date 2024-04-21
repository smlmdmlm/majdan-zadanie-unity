using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the object moves towards the player

    void Update()
    {
        // Find all GameObjects with the "Player" tag
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        // If there are no players found, exit the method
        if (players.Length == 0)
            return;

        // Calculate the average position of all players
        Vector3 averagePosition = Vector3.zero;
        foreach (GameObject player in players)
        {
            averagePosition += player.transform.position;
        }
        averagePosition /= players.Length;

        // Calculate the direction towards the average position
        Vector3 direction = averagePosition - transform.position;

        // Normalize the direction vector to get a unit vector
        direction.Normalize();

        // Move the object towards the average position
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}