using UnityEngine;
using UnityEngine.UI;

public class GetScoreAndLevel : MonoBehaviour
{
    int Score;
    int Level;
    Text ScoreText;
    private void Start()
    {
        ScoreText = GetComponent<Text>();
        if (PlayerPrefs.HasKey("Score"))
        {
            Score = PlayerPrefs.GetInt("Score");
            Level = PlayerPrefs.GetInt("Level");
            ScoreText.text = "Level: " + Level + " | " + "Score: " + Score;
        }
        else
        {
            ScoreText.text = "Press to Play!";
        }
    }
}
