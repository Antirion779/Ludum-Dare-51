using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Folder : MonoBehaviour
{
    public static Folder openedFolder = null;
    public GameObject linkToActivate;

    private void OnMouseDown()
    {
        if(openedFolder != null)
        {
            openedFolder.SetOpen(false);
        }
        SetOpen(true);
    }


    public void SetOpen(bool open)
    {
        linkToActivate.SetActive(open);
        if (open) openedFolder = this;
    }

}
