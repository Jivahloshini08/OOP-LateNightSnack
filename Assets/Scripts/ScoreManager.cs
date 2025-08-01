using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int currentScore = 0;
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded; // 🔁 hook into scene change
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Find the new scoreText in the scene by tag or name
        GameObject textObj = GameObject.FindWithTag("ScoreText");
        if (textObj != null)
            scoreText = textObj.GetComponent<TextMeshProUGUI>();

        UpdateScoreText(); // refresh score on new level
    }

    public void AddScore(int value)
    {
        currentScore += value;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = currentScore + " points";
    }
}