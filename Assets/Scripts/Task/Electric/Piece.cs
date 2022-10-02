using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public int goodState, currentState;
    public bool isCorrect;
    public bool only2RotationPiece;

    private void Update()
    {
        if(goodState == currentState)
        {
            isCorrect = true;
        } else
        {
            isCorrect = false;
        }
    }

    private void OnMouseDown()
    {
        if (!only2RotationPiece)
        {
            currentState++;
            if (currentState > 3) currentState = 0;
            transform.rotation = Quaternion.Euler(0, 0, currentState * 90);
        } else
        {
            currentState++;
            if (currentState > 1) currentState = 0;
            transform.rotation = Quaternion.Euler(0, 0, currentState * 90);
        }
        
    }
}
