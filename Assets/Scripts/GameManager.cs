using UnityEngine;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{

    public Text scoretext1;
    public Text scoretext2;
    public static bool gameRunning;
    public Ball ball;
    public int score1;
    public int score2;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartRond();
    }

    private void StartRond()
    {
        if (gameRunning)
            return;
        gameRunning = true;
        ball.InitialBallImulse();
    }

    public void IncreaseScore(bool player)
    {
        if (player)
            score1++;
        else
            score2++;

        CheckEndMatch();
        UpdateScoreTexts();
    }
    private void CheckEndMatch()
    {
        if(score1==3 || score2 == 3)
        {
            if (score1 == 3)
            {
                Debug.Log("player 1 wins");
            }
            else
            {
                Debug.Log("AI wins");
            }
            score1 = 0;
            score2 = 0;
            UpdateScoreTexts();
        }
    }


    private void UpdateScoreTexts()
    {
        scoretext1.text = score1.ToString();
        scoretext2.text = score2.ToString();
    }
}
