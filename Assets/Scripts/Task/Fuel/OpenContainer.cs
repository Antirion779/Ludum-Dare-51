using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OpenContainer : MonoBehaviour
{

    public GameObject door;
    public string[] listFuel = { "Coffee", "Water", "Gas" };
    public TextMeshProUGUI text;

    private void OnMouseDown()
    {
        door.SetActive(true);
        gameObject.SetActive(false);

        int tabValue = Random.Range(0, 3);
        text.text = listFuel[tabValue];

        Destroy(this);
    }
}
