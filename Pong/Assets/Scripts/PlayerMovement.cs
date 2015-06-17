using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Vector2 playerResetPos;
    
    private Rigidbody2D rigidbody2d;
    private GameController gameController;
    private GameObject board;
    private float playerYMin;
    private float playerYMax;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        gameController = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<GameController>();
        board = GameObject.FindGameObjectWithTag(Tags.Board);
        playerYMax = (board.transform.localScale.y / 2f - transform.localScale.y / 2f) / 100f;
        playerYMin = playerYMax * -1f;
    }

    void FixedUpdate()
    {
        if (!gameController.gameOver)
        {
            int moveVertical;
            if(gameObject.name.Equals("Player1"))
            {
                moveVertical = (int)Input.GetAxisRaw("Vertical1");
            }
            else
            {
                moveVertical = (int)Input.GetAxisRaw("Vertical2");
            }

            float newYPos = rigidbody2d.position.y + (moveVertical * speed / 100f);

            rigidbody2d.position = new Vector2
            (
                rigidbody2d.position.x,
                Mathf.Clamp(newYPos, playerYMin, playerYMax)
            );
        }
    }
}
