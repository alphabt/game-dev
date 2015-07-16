using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
    [HideInInspector]
    public bool gameOver;
    public int winScore;
    public TextMesh player1ScoreText;
    public TextMesh player2ScoreText;
    public GameObject winText;
    public GameObject restartText;
    public GameObject ball;
	public GameObject player1;
	public GameObject player2;

    private int player1Score;
    private int player2Score;

    void Awake()
    {
        player1Score = 0;
        player2Score = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }

        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.touches.Length > 0)
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    public void IncrementScore(Enums.Players player)
    {
        if (player.Equals(Enums.Players.Player1))
        {
            player1Score++;
            player1ScoreText.text = player1Score.ToString();
        }
        else
        {
            player2Score++;
            player2ScoreText.text = player2Score.ToString();
        }

        if (player1Score == winScore)
        {
            GameOver(Enums.Players.Player1);
        }
        else if (player2Score == winScore)
        {
            GameOver(Enums.Players.Player2);
        }
    }

    private void GameOver(Enums.Players player)
    {
        gameOver = true;

        // Display winning text
        winText.GetComponent<Text>().text = string.Format("{0} WINS", player.ToString().ToUpper());
        winText.SetActive(true);

        // Display restart text
        restartText.SetActive(true);

        // Disable ball rendering
        ball.SetActive(false);

		// Disable paddle rendering
		player1.SetActive(false);
		player2.SetActive(false);
    }
}
