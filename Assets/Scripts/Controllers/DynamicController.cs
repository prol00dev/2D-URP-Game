using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DynamicController : MonoBehaviour
{
    public KeyCode moveUpKey = KeyCode.UpArrow;
    public KeyCode moveRightKey = KeyCode.RightArrow;
    public KeyCode moveLeftKey = KeyCode.LeftArrow;
    public KeyCode moveDownKey = KeyCode.DownArrow;
    public KeyCode jumpKey = KeyCode.Space;

    public float MoveForce = 0.5f;
    public float MoveUpForce = 0.2f;
    public float MoveDownForce = 0.2f;
    public float brakeForce = 0.01f;

    protected Rigidbody2D rb;

    private bool isFlying = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        bool anyKeyPressed = false;

        if (Input.GetKey(moveUpKey))
        {
            rb.AddForce(Vector2.up * MoveUpForce);
            anyKeyPressed = true;
        }
        if (Input.GetKey(moveDownKey))
        {
            rb.AddForce(Vector2.down * MoveDownForce);
            anyKeyPressed = true;
        }    
        if (Input.GetKey(moveRightKey))
        {
            rb.AddForce(Vector2.right * MoveForce);
            anyKeyPressed = true;
        }
        if (Input.GetKey(moveLeftKey))
        {
            rb.AddForce(Vector2.left * MoveForce);
            anyKeyPressed = true;
        }
        if (!anyKeyPressed && !isFlying)
        {
            rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, Vector2.zero, brakeForce);
            rb.angularVelocity = Mathf.Lerp(rb.angularVelocity, 0f, brakeForce);
            Debug.Log("brake = true");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверяем, касается ли объект земли
        if (collision.gameObject.tag == "Ground")
        {
            isFlying = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Если объект перестал касаться земли
        if (collision.gameObject.tag == "Ground")
        {
            isFlying = true;
            Debug.Log("i'm fall down");
        }
    }
}
