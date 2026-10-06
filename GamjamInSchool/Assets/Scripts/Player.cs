using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public PlayerInput playerInput;


    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private bool canJump;
    private void FixedUpdate()
    {
        Vector2 moveInput = playerInput.actions["Move"].ReadValue<Vector2>();
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y) * moveSpeed * Time.fixedDeltaTime;
        transform.Translate(move, Space.World); 

        if (playerInput.actions["Jump"].IsPressed() && canJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Kill();
        }

        if (collision.gameObject.CompareTag("win"))
        {
            GameManager.Instance.Win();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Jumpable"))
        {
            canJump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        canJump = false;
    }

    public void Kill()
    {
        GameManager.Instance.Lose();
        Time.timeScale = 0f;
    }
}
