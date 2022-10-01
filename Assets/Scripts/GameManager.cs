using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private GameObject[] tasks;

    private bool resetChrono;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    // Start is called before the first frame update
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Chrono()
    {
        resetChrono = false;
        yield return new WaitForSecondsRealtime(10.0f);

        //lance un mini jeu
    }
}
