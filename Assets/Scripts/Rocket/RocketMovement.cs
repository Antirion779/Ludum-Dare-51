using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{

    public float speedLimit = 10f;
    public float force = 200f;
    public Rigidbody2D rb;

    private void Update()
    {

        if(rb.velocity.y > speedLimit)
        {
            rb.velocity = new Vector2(0, speedLimit);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, force), ForceMode2D.Force);
        }
    }

}
