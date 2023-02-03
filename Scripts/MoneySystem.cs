using UnityEngine;
using System.Collections;

public class MoneySystem : MonoBehaviour
{
    public int playerMoney = 0;

    public void AddMoney(int amount)
    {
        playerMoney += amount;
    }

    public void DeductMoney(int amount)
    {
        if (playerMoney >= amount)
        {
            playerMoney -= amount;
        }
        else
        {
            Debug.Log("Not enough money to make purchase");
        }
    }

    public bool CanAfford(int cost)
    {
        return playerMoney >= cost;
    }

    public void OnBuyItem(int cost)
    {
        DeductMoney(cost);
    }
}
