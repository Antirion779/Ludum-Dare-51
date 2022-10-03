using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Trash : MonoBehaviour
{

    public File file;
    public GameObject manager;
    public static Trash Instance;
    public TextMeshProUGUI text;

    private void Awake()
    {
        Instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<File>())
        {
            file = collision.GetComponent<File>();

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<File>())
        {
            file = null;
        }
    }

    public void Check()
    {
        if (file != null)
        {
            if (file.isCorrupted)
            {
                Destroy(file.gameObject);
                text.text = "SYSTEM INTEGRITY<br>RESTORED";
                text.color = new Color(0, 0, 0);
                GameManager.Instance.reset();
                Destroy(manager, 1f);
                Destroy(this);
            } else
            {
                file.gameObject.transform.position = file.startPosition;
            }
        }
    }
}
