using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTask : MonoBehaviour
{

    public GameObject toActivate;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartTaskSecond());
    }

    IEnumerator StartTaskSecond()
    {
        yield return new WaitForSeconds(1f);
        toActivate.SetActive(true);
    }
}
