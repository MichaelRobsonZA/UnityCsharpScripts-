using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    // The maximum health of the player
    public float maxHealth = 100f;

    // The current health of the player
    private float currentHealth;

    // The position to respawn the player after death
    public Transform respawnPoint;

    void Start()
    {
        // Set the initial health to the maximum health
        currentHealth = maxHealth;
    }

    void Update()
    {
        // Check if the player is dead
        if (currentHealth <= 0)
        {
            // Respawn the player
            Respawn();
        }
    }

    public void TakeDamage(float damage)
    {
        // Decrement the current health by the damage amount
        currentHealth -= damage;
    }

    private void Respawn()
    {
        // Set the player's position to the respawn point
        transform.position = respawnPoint.position;

        // Set the player's health back to the maximum health
        currentHealth = maxHealth;
    }
}
