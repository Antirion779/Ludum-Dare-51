using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakGlass : MonoBehaviour
{

    public bool isBreak = false;
    public DragObject dragChiffon;
    public CircleCollider2D chiffonCollider;
    public SpriteRenderer glass;
    public Sprite shattered;
    private void OnMouseDown()
    {
        isBreak = true;
        dragChiffon.canBeDrag = true;
        chiffonCollider.enabled = true;
        glass.sprite = shattered;
        glass.sortingOrder = 2;
        SoundManager.Instance.PlaySound("glass2");
    }
}
