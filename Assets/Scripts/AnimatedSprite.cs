using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AnimatedSprite : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get; private set; }
    public Sprite[] sprites;
    public float animTime = 0.25f;
    public int animFrame {  get; private set; }
    public bool loop = true;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(Advance), animTime, animTime);
    }

    private void Advance()
    {
        if (spriteRenderer.enabled)
        {
            animFrame++;
            if (animFrame >= sprites.Length && loop)
            {
                animFrame = 0;
            }

            if (animFrame >= 0 && animFrame < sprites.Length)
            {
                spriteRenderer.sprite = sprites[animFrame];
            }
        }
    }

    public void Restart()
    {
        animFrame = -1;

        Advance();
    }
}
