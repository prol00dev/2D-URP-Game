using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DynamicController : MonoBehaviour
{
    public enum State
    {
        Idle,
        Run,
        Jump
    }

    public State CurrentState { get; private set; }

    public KeyCode moveUpKey = KeyCode.UpArrow;
    public KeyCode moveRightKey = KeyCode.RightArrow;
    public KeyCode moveLeftKey = KeyCode.LeftArrow;
    public KeyCode moveDownKey = KeyCode.DownArrow;

    public float moveSpeed = 5f;

    protected Rigidbody2D rb;
    public bool isFlying = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        Vector2 moveDir = Vector2.zero;

        if (Input.GetKey(moveUpKey)) moveDir += Vector2.up;
        if (Input.GetKey(moveDownKey)) moveDir += Vector2.down;
        if (Input.GetKey(moveRightKey)) moveDir += Vector2.right;
        if (Input.GetKey(moveLeftKey)) moveDir += Vector2.left;

        rb.linearVelocity = moveDir.normalized * moveSpeed;

        // === Обновление состояния ===
        if (isFlying)
        {
            CurrentState = State.Jump;
        }
        else if (moveDir != Vector2.zero)
        {
            CurrentState = State.Run;
        }
        else
        {
            CurrentState = State.Idle;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isFlying = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isFlying = true;
            Debug.Log("i'm fall down");
        }
    }
}
