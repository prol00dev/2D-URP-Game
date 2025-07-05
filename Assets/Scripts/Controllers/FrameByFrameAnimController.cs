using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FrameByFrameAnimController : MonoBehaviour
{
    [SerializeField] private Sprite[] idle;
    [SerializeField] private Sprite[] run;
    [SerializeField] private Sprite[] jump;

    public float frameRate = 4f;

    private SpriteRenderer spriteRenderer;
    private Sprite[] currentFrames;
    private int currentFrame;
    private float timer;

    private DynamicController dynamicController;
    private DynamicController.State lastState;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        dynamicController = GetComponent<DynamicController>();

        if (dynamicController == null)
        {
            Debug.LogError("Нет DynamicController на этом объекте!");
        }

        UpdateAnimationState(dynamicController.CurrentState);
    }

    void Update()
    {
        if (dynamicController == null) return;

        DynamicController.State currentState = dynamicController.CurrentState;

        if (currentState != lastState)
        {
            UpdateAnimationState(currentState);
        }

        if (currentFrames == null || currentFrames.Length == 0) return;

        timer += Time.deltaTime;

        if (timer >= 1f / frameRate)
        {
            timer = 0f;
            currentFrame = (currentFrame + 1) % currentFrames.Length;
            spriteRenderer.sprite = currentFrames[currentFrame];
        }
    }

    private void UpdateAnimationState(DynamicController.State state)
    {
        lastState = state;
        currentFrame = 0;
        timer = 0;

        switch (state)
        {
            case DynamicController.State.Idle:
                currentFrames = idle;
                break;
            case DynamicController.State.Run:
                currentFrames = run;
                break;
            case DynamicController.State.Jump:
                currentFrames = jump;
                break;
            default:
                currentFrames = idle;
                break;
        }
    }
}
