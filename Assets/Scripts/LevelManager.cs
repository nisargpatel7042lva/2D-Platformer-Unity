using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public int currentLevel = 1;
    public enum Difficulty { Easy, Medium, Hard }
    public Difficulty currentDifficulty = Difficulty.Easy;

    [SerializeField] private TMP_Text levelDisplayText;
    [SerializeField] private TMP_Text difficultyText;

    private int totalLevels = 3;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Determine level based on current scene index
        // Scene 0: Menu, Scene 1: Level 1, Scene 2: Level 2, Scene 3: Level 3
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (sceneIndex > 0)
        {
            currentLevel = sceneIndex;
            SetDifficultyBasedOnLevel();
            UpdateLevelDisplay();
        }
    }

    private void SetDifficultyBasedOnLevel()
    {
        switch (currentLevel)
        {
            case 1:
                currentDifficulty = Difficulty.Easy;
                break;
            case 2:
                currentDifficulty = Difficulty.Medium;
                break;
            case 3:
                currentDifficulty = Difficulty.Hard;
                break;
            default:
                currentDifficulty = Difficulty.Easy;
                break;
        }
    }

    private void UpdateLevelDisplay()
    {
        if (levelDisplayText != null)
            levelDisplayText.text = "LEVEL " + currentLevel;

        if (difficultyText != null)
            difficultyText.text = "Difficulty: " + currentDifficulty.ToString().ToUpper();
    }

    public void GoToNextLevel()
    {
        if (currentLevel < totalLevels)
        {
            SceneManager.LoadScene(currentLevel + 1);
        }
        else
        {
            // All levels complete - go to menu or show completion screen
            Debug.Log("All levels completed!");
            SceneManager.LoadScene(0);
        }
    }

    public void GoToLevel(int levelNumber)
    {
        if (levelNumber > 0 && levelNumber <= totalLevels)
        {
            SceneManager.LoadScene(levelNumber);
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    public Difficulty GetCurrentDifficulty()
    {
        return currentDifficulty;
    }

    public bool IsHardMode()
    {
        return currentDifficulty == Difficulty.Hard;
    }

    public bool IsMediumMode()
    {
        return currentDifficulty == Difficulty.Medium;
    }
}
