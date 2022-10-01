using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    public bool canBeDrag = true;
    Vector2  diff = Vector2.zero;

    private void OnMouseDown()
    {
        if (canBeDrag)
            diff = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2) transform.position;
    }

    private void OnMouseDrag()
    {
        if (canBeDrag)
            transform.position = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition) - diff;
    }
}
