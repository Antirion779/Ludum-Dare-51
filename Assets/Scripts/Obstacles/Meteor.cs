using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed = 4;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameObject.tag = "Meteor";
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(-speed, 0, 0);
    }
}
