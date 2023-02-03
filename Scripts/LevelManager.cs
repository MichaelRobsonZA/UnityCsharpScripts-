using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    void Start()
    {
        // Load the first level
        LoadLevel("Level1");
    }

    // Load a level by name
    public void LoadLevel(string levelName)
    {
        // Unload the current level
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

        // Load the new level
        SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
    }
}

