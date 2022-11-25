using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 10;

    public Collider2D PaddleLeft;
    public Collider2D PaddleRight;
    public Collider2D GollLeft;
    public Collider2D GollRight;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void InitialBallImulse()
    {
        rb.velocity = transform.right * speed;
    }

    public void ResetBall()
    {
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        GameManager.gameRunning = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider == PaddleLeft || collision.collider == PaddleRight)
        {
            float y = transform.position.y - collision.transform.position.y;
            float x = 0;

            if (collision.collider == PaddleLeft)
                x = 1;
            else
                x = -1;

            Vector2 dir = new Vector2(x, y).normalized;
            rb.velocity = dir * speed;
            collision.transform.GetComponent<AudioSource>().Play();
        }
        

        if(collision.collider == GollLeft || collision.collider == GollRight)
        {
            if (collision.collider == GollRight)
                FindObjectOfType<GameManager>().IncreaseScore(true);
            else
                FindObjectOfType<GameManager>().IncreaseScore(false);
            ResetBall();
        }
    }


}
