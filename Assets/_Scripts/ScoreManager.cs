
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [SerializeField] private TMP_Text scoreText;

    public int Score { get; private set; }

    void Awake()
    {
        Instance = this;
        Score = 0;
        UpdateUI();
        PlayerPrefs.SetInt("FinalScore", 0);//
    }

    public void AddScore(int amount)
    {
        Score += amount;
        UpdateUI();
        PlayerPrefs.SetInt("FinalScore", Score);//
    }

    void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "SCORE: " + Score;
    }
}
