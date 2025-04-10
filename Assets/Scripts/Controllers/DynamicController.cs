using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DynamicController : MonoBehaviour
{
    public KeyCode moveUpKey = KeyCode.UpArrow;
    public KeyCode moveRightKey = KeyCode.RightArrow;
    public KeyCode moveLeftKey = KeyCode.LeftArrow;
    public KeyCode moveDownKey = KeyCode.DownArrow;

    public float MoveForce = 0.5f;
    public float MoveUpForce = 0.2f;
    public float MoveDownForce = 0.2f;

    public Rigidbody2D rb;

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
        if (!anyKeyPressed)
        {
            rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, Vector2.zero, 0.01f);
            rb.angularVelocity = Mathf.Lerp(rb.angularVelocity, 0f, 0.01f);
        }

    }
}
