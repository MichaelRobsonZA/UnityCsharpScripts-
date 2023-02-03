using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Text healthText;
    public Text reloadSpeedText;
    public Text movementSpeedText;
    public Text damageText;

    private PlayerStats playerStats;

    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
    }

    private void Update()
    {
        healthText.text = "Health: " + playerStats.health;
        reloadSpeedText.text = "Reload Speed: " + playerStats.reloadSpeed;
        movementSpeedText.text = "Movement Speed: " + playerStats.movementSpeed;
        damageText.text = "Damage: " + playerStats.damage;
    }
}
