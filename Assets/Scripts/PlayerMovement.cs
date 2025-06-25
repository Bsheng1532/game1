using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("PlayerMovement script started.");
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);

        if (moveX != 0)
            Debug.Log("Moving: " + moveX);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space key pressed.");
            if (isGrounded)
            {
                Debug.Log("Player is grounded. Jumping!");
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            }
            else
            {
                Debug.Log("Player is NOT grounded. No jump.");
            }
        }
    }

void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Ground"))
    {
        isGrounded = true;
    }

    if (collision.gameObject.CompareTag("Goose"))
    {
        Debug.Log("Hit by Goose! Restarting level...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            Debug.Log("Grounded = false");
        }
    }
}
