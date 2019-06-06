using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private SpriteRenderer spr;
    private Sprite[] sprites;

    public float frameDelay = .2f;
    float timeCount = 0f;
    int frame = 0;

    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        sprites = Resources.LoadAll<Sprite>("Explosions");
    }

    void Update()
    {
        timeCount += Time.deltaTime;
        if (timeCount > frameDelay)
        {
            timeCount = 0;
            frame++;
            if (frame >= sprites.Length)
            {
                Destroy(this.gameObject);
            }
            else
            {
                spr.sprite = sprites[frame];
            }
        }
    }
}