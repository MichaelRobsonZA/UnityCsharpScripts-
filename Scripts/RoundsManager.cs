using UnityEngine;
using System.Collections;

public class RoundsManager : MonoBehaviour
{
    public GameObject zombiePrefab;
    public int maxZombies = 10;
    public int zombiesPerRound = 5;
    private int currentRound = 0;
    private int remainingZombies = 0;
    private ArrayList zombies = new ArrayList();

    private void Start()
    {
        StartRound();
    }

    private void StartRound()
    {
        remainingZombies = zombiesPerRound;

        for (int i = 0; i < zombiesPerRound; i++)
        {
            SpawnZombie();
        }

        currentRound++;
    }

    private void SpawnZombie()
    {
        if (zombies.Count >= maxZombies)
        {
            return;
        }

        GameObject newZombie = Instantiate(zombiePrefab);
        zombies.Add(newZombie);
    }

    public void ZombieDied()
    {
        remainingZombies--;

        if (remainingZombies <= 0)
        {
            StartRound();
        }
    }
}
