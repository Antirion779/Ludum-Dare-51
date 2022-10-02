using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private GameObject[] tasks;
    [SerializeField] private GameObject currentTask;

    [Header("BackGround")]
    [SerializeField] private GameObject backGround;
    [SerializeField] private int backGroundSpeed = 1;

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

        backGround.GetComponent<Renderer>().material.mainTextureOffset += new Vector2(backGroundSpeed * Time.deltaTime, 0);
    }

    IEnumerator Chrono()
    {
        resetChrono = false;
        Debug.Log("Before");
        yield return new WaitForSecondsRealtime(10.0f);

        StartTask();
        Debug.Log("After");
        //lance un mini jeu
    }

    private void StartTask()
    {
        int i = Random.Range(0, tasks.Length);
        currentTask = Instantiate(tasks[i]);
        MeteorSpawner.Instance.questActive = true;

        {
            foreach (GameObject meteor in MeteorSpawner.Instance.meteorsList)
            {
                Destroy(meteor);
            }
            MeteorSpawner.Instance.meteorsList.Clear();
        }
    }

    public void reset()
    {
        Destroy(currentTask);
        resetChrono = true;
        MeteorSpawner.Instance.questActive = false;
    }
}
