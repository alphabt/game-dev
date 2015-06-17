using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
    [HideInInspector]
    public bool gameOver;
    public int winScore;
    public Text player1ScoreText;
    public Text player2ScoreText;
    public GameObject winText;
    public GameObject restartText;
    public GameObject ball;

    private int player1Score;
    private int player2Score;

    void Awake()
    {
        player1Score = 0;
        player2Score = 0;
//        float camHalfHeight = Camera.main.orthographicSize;
//        float camHalfWidth = Camera.main.aspect * camHalfHeight;
//
//        GameObject newBoard = Instantiate(board, Vector3.zero, Quaternion.identity) as GameObject;
//        newBoard.transform.localScale = new Vector3(camHalfWidth * 2f * 100, camHalfHeight * 2f * 100, 0f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }

        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Return))
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
    }
}
