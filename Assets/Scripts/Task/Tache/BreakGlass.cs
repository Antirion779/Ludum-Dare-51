using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakGlass : MonoBehaviour
{

    public bool isBreak = false;
    public GameObject leChiffonLa;
    private void OnMouseDown()
    {
        isBreak = true;
        leChiffonLa.SetActive(true);
    }
}
