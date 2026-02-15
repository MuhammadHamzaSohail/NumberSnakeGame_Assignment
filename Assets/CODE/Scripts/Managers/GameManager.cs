using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject gameOverPanel;

    public bool isGameActive;

    void Awake()
    {
        Instance = this;
    }

    public void StartGame()
    {
        isGameActive = true;
    }

    public void StopGame()
    {
        isGameActive = false;
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
