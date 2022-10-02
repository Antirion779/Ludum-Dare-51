using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class File : MonoBehaviour
{
    public Vector3 startPosition;
    public bool isCorrupted = false;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void OnMouseUp()
    {
        if(Trash.Instance.file == null)
        {
            transform.position = startPosition;
        } else if(Trash.Instance.file == this)
        {
            Trash.Instance.Check();
        }
    }
}
