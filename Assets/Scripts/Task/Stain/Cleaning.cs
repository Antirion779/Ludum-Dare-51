using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaning : MonoBehaviour
{
    public SpriteRenderer sprite;
    public float diff = 0.01f;
    public bool isNettoye = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.name == "Chiffon")
        {
            sprite.color = new Color(0.3443396f, 1.0f, 0.4134772f, sprite.color.a - diff);
            Debug.Log(sprite.color.a);
            if(!SoundManager.Instance.source.isPlaying) SoundManager.Instance.PlaySound("wipe"+Random.Range(1,4));

            if (sprite.color.a <= 0)
            {
                isNettoye = true;
            }
        }
    }
}
