using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<Piece> pieces = new();
    public GameObject manager;

    private void Start()
    {
        manager = transform.parent.gameObject;
        foreach(Piece piece in pieces)
        {
            int r = 0;
            while(r == piece.goodState) r = Random.Range(0, 4);
            piece.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, r * 90));
            piece.currentState = r;
        }
    }

    private void Update()
    {
        foreach(Piece piece in pieces)
        {
            if (!piece.isCorrect) return;
        }
        GameManager.Instance.reset();
        Destroy(manager, 1f);
        Destroy(this);
    }
}
