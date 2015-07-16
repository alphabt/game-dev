using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public int speed;

    private Rigidbody2D rigidbody2d;
    private GameController gameController;
    private Vector2 direction;
    private Vector2 resetPos;
    private bool isReset;
    private float xDirection;
    
    public void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        gameController = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<GameController>();
        resetPos = new Vector2(0, 0);
        isReset = true;
        xDirection = 1f;
    }
    
    public void Update()
    {
        // Check if it's in reset position
        if (isReset)
        {
            isReset = false;
            direction = new Vector2(xDirection, Random.Range(-0.5f, 0.5f));
            xDirection = -xDirection;
            SetDirection(direction);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == Tags.GoalLeft)
        {
            gameController.IncrementScore(Enums.Players.Player1);
            ResetBall();
        }
        else if (collision.collider.tag == Tags.GoalRight)
        {
            gameController.IncrementScore(Enums.Players.Player2);
            ResetBall();
        }
        else
        {
            // Hit something and bounce
            Vector2 collisionNormal = collision.contacts[0].normal;
            direction = Vector3.Reflect(direction, collisionNormal);
            SetDirection(direction);
        }
    }
    
    private void SetDirection(Vector2 direction)
    {
        direction.Normalize();
        rigidbody2d.velocity = Vector2.zero;
        rigidbody2d.AddForce(direction * speed);
    }

    private void ResetBall()
    {
        isReset = true;
        transform.position = resetPos;
    }
}
