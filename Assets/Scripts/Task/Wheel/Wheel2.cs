using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel2 : MonoBehaviour
{

    public bool isPink = false;
    public Vector3 startPos;
    public GameObject manager, pinkWheelChecker;
    public Wheel2 otherWheel;

    // Start is called before the first frame update

    private void OnMouseUp()
    {
        if (!isPink && WheelTrash.Instance.current != null && WheelTrash.Instance.current.name == gameObject.name)
        {
            pinkWheelChecker.SetActive(true);
            Destroy(gameObject);
        } else if (isPink)
        {
            GetComponent<SpriteRenderer>().sortingOrder = 3;
            if(NewWheel.Instance != null && NewWheel.Instance.current != null && NewWheel.Instance.current.name == gameObject.name)
            {
                GameManager.Instance.reset();
                Destroy(manager, 1f);
            } else
            {
                transform.localPosition = startPos;
                otherWheel.gameObject.transform.localPosition = otherWheel.startPos;
            }
        }
        else
        {
            transform.localPosition = startPos;
            otherWheel.gameObject.transform.localPosition = otherWheel.startPos;
        }
    }

    private void OnMouseDown()
    {
        if (isPink) GetComponent<SpriteRenderer>().sortingOrder = 5;
    }
}

