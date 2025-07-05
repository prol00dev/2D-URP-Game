using System;
using UnityEngine;

public class FrameByFrameAnimController : MonoBehaviour
{
    [SerializeField] private Sprite[] frames;
    [SerializeField] private Sprite[] idle;
    [SerializeField] private Sprite[] walk;
    [SerializeField] private Sprite[] run;
    [SerializeField] private Sprite[] jump;
    public float frameRate = 4f;

    private SpriteRenderer spriteRenderer;
    private int currentFrame;
    private float timer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (frames.Length == 0) return;

        timer += Time.deltaTime;

        if (timer >= 1f / frameRate)
        {
            timer = 0f;
            currentFrame = (currentFrame + 1) % frames.Length;
            spriteRenderer.sprite = frames[currentFrame];
        }
    }
}

