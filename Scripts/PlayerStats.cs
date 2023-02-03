using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health;
    public int damage;
    public float reloadSpeed;
    public float movementSpeed;

    private int startingHealth;
    private float startingReloadSpeed;
    private float startingMovementSpeed;

    private void Start()
    {
        // Store the starting values of the player's stats
        startingHealth = health;
        startingReloadSpeed = reloadSpeed;
        startingMovementSpeed = movementSpeed;
    }

    public void ApplyPerk(PerkType perkType, int perkValue)
    {
        // Increase or decrease the player's stats based on the perk they bought
        switch (perkType)
        {
            case PerkType.Health:
                health += perkValue;
                break;
            case PerkType.Damage:
                damage += perkValue;
                break;
            case PerkType.ReloadSpeed:
                reloadSpeed -= perkValue;
                break;
            case PerkType.MovementSpeed:
                movementSpeed += perkValue;
                break;
        }
    }

    public void ResetStats()
    {
        // Reset the player's stats back to their starting values
        health = startingHealth;
        reloadSpeed = startingReloadSpeed;
        movementSpeed = startingMovementSpeed;
    }
}

public enum PerkType
{
    Health,
    Damage,
    ReloadSpeed,
    MovementSpeed
}
