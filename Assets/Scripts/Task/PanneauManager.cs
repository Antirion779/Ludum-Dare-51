using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanneauManager : MonoBehaviour
{
    [SerializeField] private GameObject[] BaseDontMove;
    [SerializeField] private GameObject[] BaseMove;


    void OnEnable()
    {
        foreach (GameObject item in BaseMove)
        {
            int x = Random.Range(-8, 8);
            int y = Random.Range(2, 4);

            item.GetComponent<DragObject>().canBeDrag = true;
            item.transform.position = new Vector2(x, y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject item in BaseDontMove)
        {
            RaycastHit2D hit = Physics2D.Raycast(item.transform.position, Vector2.up, 2.0f);
            Debug.DrawRay(item.transform.position, Vector2.up, Color.green);
            if (hit.collider != null && hit.transform.name == item.transform.name)
            {
                //hit.collider.GetComponent<SpriteRenderer>().color = Color.green;
                hit.collider.GetComponent<DragObject>().canBeDrag = false;
                hit.transform.position = new Vector2(item.transform.position.x, item.transform.position.y + 2);
            }

        }
    }
}
