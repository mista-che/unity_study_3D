using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI currentscore_display;
    public TextMeshProUGUI highscore_display;

    private int current_score;
    private int high_score;

    private void Start()
    {
        // load highscore. 0 is fallback value if key is null.
        high_score = PlayerPrefs.GetInt("Airplanes_Highscore", 0);
    }

    private void Update()
    {
        currentscore_display.SetText($"현재 점수: {current_score}");
        highscore_display.SetText($"최고 점수: {current_score}");
    }

    public int GetScore()
    {
        return current_score;
    }

    public void SetScore(int a)
    {
        current_score = a;

        if (current_score >= high_score)
        {
            high_score = current_score;
            PlayerPrefs.SetInt("Airplanes_Highscore", high_score);
        }
    }

    public int GetHighscore()
    {
        return high_score;
    }    
}
