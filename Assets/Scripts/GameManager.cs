using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private GameObject[] tasks;
    [SerializeField] public GameObject currentTask;

    [Header("BackGround")]
    [SerializeField] private GameObject backGround;
    [SerializeField] private float backGroundSpeed = 1;

    public float increaseSpeed = 0.05f;

    public bool resetChrono = true;

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
        resetChrono = true;
        RocketScoring.Instance.score += RocketScoring.Instance.taskAddScore;
        MeteorSpawner.Instance.questActive = false;
        MeteorSpawner.Instance.meteorSpeed += increaseSpeed;
    }

    public IEnumerator Kill()
    {
        Time.timeScale = 0f;
        yield return new WaitForSeconds(1f);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Antoine Bis");
    }

}
