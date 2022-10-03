using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RocketScoring : MonoBehaviour
{
    public int addScore = 100, taskAddScore = 500;
    public float cooldown = 1f;
    public int score = 0;
    public TextMeshProUGUI text;
    public static RocketScoring Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        cooldown -= Time.deltaTime; 
        if (GameManager.Instance.currentTask == null && cooldown < 0)
        {
            score++;
            cooldown = 1f;
        }
        text.text = "" + score;
    }
}
