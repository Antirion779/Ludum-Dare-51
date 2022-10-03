using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskComplete : MonoBehaviour
{
    public GameObject taskComplete;

    private void Awake()
    {
        GameManager.Instance.taskComplete = taskComplete;
    }

}
