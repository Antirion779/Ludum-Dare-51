using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public bool isActive = false;
    public GameObject gloveWheel;
    public Sprite actived;

    private void OnMouseDown()
    {
        if (isActive) return;
        isActive = true;
        gloveWheel.SetActive(true);
        GetComponent<SpriteRenderer>().sprite = actived;
        SoundManager.Instance.PlayMusic("sanandreas");
        GameManager.Instance.SetMainMusic(false);
    }
}
