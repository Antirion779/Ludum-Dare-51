using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObjectReal : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool canBeDrag = true;
    Vector2  dir = Vector2.zero;
    Vector2 center = Vector2.zero;
    Vector2 last_pos = Vector2.zero;
    Vector2 diff = Vector2.zero;

    private void OnMouseDown()
    {
        if (canBeDrag)
            center = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);
            last_pos = (Vector2) transform.position;
    }

    private void OnMouseDrag(){
        if (canBeDrag){
            diff = last_pos - (Vector2) transform.position;
            center = center - diff;
            dir = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition) - center;
            Debug.DrawRay(center, dir, Color.blue);
            rb.AddForce(dir, ForceMode2D.Force);
            last_pos = (Vector2) transform.position;
        }
    }
}
