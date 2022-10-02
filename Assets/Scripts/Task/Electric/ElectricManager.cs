using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricManager : MonoBehaviour
{
    public List<GameObject> levels = new();

    void Start()
    {
        int r = Random.Range(0, levels.Count);
        Instantiate(levels[r], gameObject.transform);
    }

}
