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
            sprite.color = new Color(1f, 1f, 1f, sprite.color.a - diff);
            Debug.Log(sprite.color.a);

            if (sprite.color.a <= 0)
            {
                isNettoye = true;
            }
        }
    }
}
