using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewWheel : MonoBehaviour
{

    public Wheel2 current;
    public static NewWheel Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        current = collision.gameObject.GetComponent<Wheel2>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        current = null;
    }

    

}
