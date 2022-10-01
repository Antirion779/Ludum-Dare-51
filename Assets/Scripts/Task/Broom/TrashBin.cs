using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : MonoBehaviour
{

    public BroomManager broomManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Dust")
        {
            broomManager.dust.Remove(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
