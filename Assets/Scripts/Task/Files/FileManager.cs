using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileManager : MonoBehaviour
{

    public File[] fileList = new File[12];
    public GameObject corruptedIndicator;

    private void Start()
    {
        int corrupted = Random.Range(0, fileList.Length);
        fileList[corrupted].isCorrupted = true;
        corruptedIndicator.transform.SetParent(fileList[corrupted].gameObject.transform);
        corruptedIndicator.transform.localPosition = new Vector3(0, 0, 0);
        corruptedIndicator.SetActive(true);
    }

}
