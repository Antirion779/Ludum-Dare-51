using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacheManager : MonoBehaviour
{

    public List<Cleaning> listTache;

    private void Update()
    {
        foreach(Cleaning cleaning in listTache)
        {
            if (!cleaning.isNettoye) return;
        }
        GameManager.Instance.reset();
        Destroy(gameObject, 1f);
    }

}
