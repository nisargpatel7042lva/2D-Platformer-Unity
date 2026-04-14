using UnityEngine;

/// <summary>
/// Adjusts level difficulty dynamically based on the current level
/// Can be used to spawn additional enemies, adjust platform heights, etc.
/// </summary>
public class LevelDifficultyAdjuster : MonoBehaviour
{
    [SerializeField] private GameObject[] mediumDifficultyObstacles;
    [SerializeField] private GameObject[] hardDifficultyObstacles;
    [SerializeField] private GameObject[] enemies;

    private LevelManager.Difficulty currentDifficulty;

    private void Start()
    {
        if (LevelManager.instance == null)
        {
            Debug.LogWarning("LevelManager not found!");
            return;
        }

        currentDifficulty = LevelManager.instance.GetCurrentDifficulty();
        ApplyDifficultyAdjustments();
    }

    private void ApplyDifficultyAdjustments()
    {
        // Disable all difficulty-specific obstacles first
        DisableAllObstacles();

        switch (currentDifficulty)
        {
            case LevelManager.Difficulty.Easy:
                Debug.Log("Level 1 - Easy Mode activated");
                // Default level layout
                break;

            case LevelManager.Difficulty.Medium:
                Debug.Log("Level 2 - Medium Mode activated");
                // Enable medium obstacles
                if (mediumDifficultyObstacles != null)
                {
                    foreach (GameObject obstacle in mediumDifficultyObstacles)
                    {
                        if (obstacle != null)
                            obstacle.SetActive(true);
                    }
                }
                break;

            case LevelManager.Difficulty.Hard:
                Debug.Log("Level 3 - Hard Mode activated");
                // Enable all obstacles
                if (mediumDifficultyObstacles != null)
                {
                    foreach (GameObject obstacle in mediumDifficultyObstacles)
                    {
                        if (obstacle != null)
                            obstacle.SetActive(true);
                    }
                }
                if (hardDifficultyObstacles != null)
                {
                    foreach (GameObject obstacle in hardDifficultyObstacles)
                    {
                        if (obstacle != null)
                            obstacle.SetActive(true);
                    }
                }
                break;
        }
    }

    private void DisableAllObstacles()
    {
        if (mediumDifficultyObstacles != null)
        {
            foreach (GameObject obstacle in mediumDifficultyObstacles)
            {
                if (obstacle != null)
                    obstacle.SetActive(false);
            }
        }

        if (hardDifficultyObstacles != null)
        {
            foreach (GameObject obstacle in hardDifficultyObstacles)
            {
                if (obstacle != null)
                    obstacle.SetActive(false);
            }
        }
    }
}
