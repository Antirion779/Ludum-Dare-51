using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private GameObject[] tasks;

    [SerializeField] public GameObject currentTask;

    [SerializeField] private int lastTask;
    [SerializeField] private int lastTaskBis; //eh c'est horrible faut jamais faire �a !!!! mais vas-y j'ai faim faut que je finisse �a rapidement 

    [Header("BackGround")]
    [SerializeField] private GameObject backGround;
    [SerializeField] private float backGroundSpeed = 1;

    public float increaseSpeed = 0.05f;
    public GameObject pauseMenu;
    public SpriteRenderer redAlert;

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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
            Time.timeScale = pauseMenu.activeInHierarchy ? 0 : 1;
        }

        backGround.GetComponent<Renderer>().material.mainTextureOffset += new Vector2(backGroundSpeed * Time.deltaTime, 0);
    }

    IEnumerator Chrono()
    {
        resetChrono = false;
        Debug.Log("Before");
        yield return new WaitForSeconds(8f);
        StartCoroutine(Alert());
        yield return new WaitForSeconds(2f);
        StartTask();
        Debug.Log("After");
        //lance un mini jeu
    }

    IEnumerator Alert()
    {
        redAlert.color = new Color(1, 0, 0, 0.2f);
        SoundManager.Instance.PlaySound("emergency");
        yield return new WaitForSeconds(0.7f);
        redAlert.color = new Color(1, 0, 0, 0f);
        yield return new WaitForSeconds(0.3f);
        SoundManager.Instance.PlaySound("emergency");
        redAlert.color = new Color(1, 0, 0, 0.2f);
        yield return new WaitForSeconds(0.7f);
        redAlert.color = new Color(1, 0, 0, 0f);
        yield return new WaitForSeconds(0.3f);
    }

    private void StartTask()
    {
        int i;
        i = Random.Range(0, tasks.Length);
        lastTaskBis = lastTask;
        lastTask = i;

        Debug.Log("Current task : " + i +" / lastTask : " + lastTask + " / lastTaskBis : " + lastTaskBis);

        while (lastTask == i || lastTaskBis == i)
            i = Random.Range(0, tasks.Length);

        lastTask = i;

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
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1f;
        Application.LoadLevel(Application.loadedLevel);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
