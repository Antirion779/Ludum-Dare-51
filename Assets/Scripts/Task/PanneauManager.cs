using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PanneauManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> BaseDontMove;
    [SerializeField] private GameObject[] BaseMove;

    [SerializeField] private int objectif;


    void OnEnable()
    {
        foreach (GameObject item in BaseMove)
        {
            int x = Random.Range(-7, 7);
            int y;
            if (x < -3 || x > 3)
                y = Random.Range(2, 3);
            else
                y = Random.Range(2, 3);

            item.GetComponent<DragObject>().canBeDrag = true;
            item.transform.position = new Vector2(x, y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Check();

        if (objectif == BaseMove.Length)
        {
            GameManager.Instance.reset();
        }
    }

    private void Check()
    {
        for (int i = BaseDontMove.Count - 1 ; i >= 0; i--)
        {
            RaycastHit2D hit = Physics2D.Raycast(BaseDontMove[i].transform.position, Vector2.up, 2.0f);
            Debug.DrawRay(BaseDontMove[i].transform.position, Vector2.up, Color.green);
            if (hit.collider != null && hit.transform.name == BaseDontMove[i].transform.name)
            {
                hit.collider.GetComponent<DragObject>().canBeDrag = false;
                hit.transform.position = new Vector2(BaseDontMove[i].transform.position.x, BaseDontMove[i].transform.position.y + 2);
                //Play Sound
                objectif++;
                BaseDontMove.Remove(BaseDontMove[i]);
            }
        }
    }
}
