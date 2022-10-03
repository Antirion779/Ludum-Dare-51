using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroomManager : MonoBehaviour
{
    public List<GameObject> dust;

    private void Update()
    {
        if(dust.Count == 0)
        {
            GameManager.Instance.reset();
            Destroy(gameObject, 1f) ;
        }
    }
}
