
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text finalScoreText;

    void Start()
    {
        int score = PlayerPrefs.GetInt("FinalScore", 0);

        if (finalScoreText != null)
            finalScoreText.text = "FINAL SCORE: " + score;
    }
}
