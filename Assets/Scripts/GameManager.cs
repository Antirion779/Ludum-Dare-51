using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private GameObject[] tasks;
    [SerializeField] private GameObject currentTask;

    private bool resetChrono = true;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }


    // Update is called once per frame
    void Update()
    {
        if (resetChrono)
        {
            StartCoroutine(Chrono());
        }
    }

    IEnumerator Chrono()
    {
        resetChrono = false;
        Debug.Log("Before");
        yield return new WaitForSecondsRealtime(2.0f);

        StartTask();
        Debug.Log("After");
        //lance un mini jeu
    }

    private void StartTask()
    {
        int i = Random.Range(0, tasks.Length);
        currentTask = Instantiate(tasks[i]);
    }

    public void reset()
    {
        Destroy(currentTask);
        resetChrono = true;
    }
}
