using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;
    public int health = 3;
    public Text healthText;
    public GameObject gameOverScreen;
    public Text highScoreText;

    private void Awake()
    {
        instance = this;
        gameOverScreen.SetActive(false);
    }
    void Start()
    {
        UpdateHealthText();
    }

    void UpdateHealthText()
    {
        healthText.text = "Health: " + health;
    }

    public void DecreaseHealth()
    {
        health--;
        UpdateHealthText();
        if (health <= 0)
        {
            GameOver();
        }
    }
    void GameOver()
    {
        ScoreManager.instance.CheckHighScore();
        ScoreManager.instance.UpdateHighScoreText();
        SpawnManager.instance.StopSpawning();
        gameOverScreen.SetActive(true);
    }

    public void RestartGame()
    {
        ScoreManager.instance.ResetScore();
        ScoreManager.instance.UpdateHighScoreText();
        health = 3;
        UpdateHealthText();
        gameOverScreen.SetActive(false);
        SpawnManager.instance.StartSpawning();
    }
}
