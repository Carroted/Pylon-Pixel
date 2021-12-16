using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Emotion
{
    public const int happy = 0;
    public const int sad = 1;
    public const int surprised = 2;
    public const int dead = 3;
}

[System.Serializable]
public class EmotionSprites
{
    public Sprite happy;
    public Sprite sad;
    public Sprite surprised;
    public Sprite dead;
}

public class Blob : MonoBehaviour
{
    public int emotion = Emotion.happy;
    public EmotionSprites sprites;
    public SpriteRenderer spriteRenderer;
    public TMP_Text text;
    public int chances = 3;
    public Health health;
    public SFX sfx;


    // If collision hurts enough, be sad
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > 2)
        {
            emotion = Emotion.sad;
            spriteRenderer.sprite = sprites.sad;
            sfx.Play(sfx.playerGetDamage);
            if (chances == 3)
            {
                text.text = "Blob sad. Blob has been in pain. Very sad. Cone will be punished if you don't stop making blob sad.";
            }
            if (chances == 2)
            {
                text.text = "Blob sadder. More pain. Cone is pushing limit.";
            }
            if (chances == 1)
            {
                text.text = "Blob sadder. More pain. Last chance. One more and cone will be executed.";
            }
            if (chances == 0)
            {
                text.text = "Blob sadder. More pain. You have pushed the limits of what was thought possible. Goodbye.";
                health.alive = false;
                NextLevel.Static(true);
            }
            chances--;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (emotion)
        {
            case Emotion.happy:
                spriteRenderer.sprite = sprites.happy;
                break;
            case Emotion.sad:
                spriteRenderer.sprite = sprites.sad;
                break;
            case Emotion.surprised:
                spriteRenderer.sprite = sprites.surprised;
                break;
            case Emotion.dead:
                spriteRenderer.sprite = sprites.dead;
                break;
        }
    }
}

