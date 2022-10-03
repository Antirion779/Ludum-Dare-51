using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OpenContainer : MonoBehaviour
{

    public GameObject door, fillbar;
    public string[] listFuel = { "Coffee", "Water", "Gas" };

    private void OnMouseDown()
    {
        door.SetActive(true);
        fillbar.SetActive(true);

        int tabValue = Random.Range(0, 3);
        StoreFuel.Instance.fuelAccepted = listFuel[tabValue];
        StoreFuel.Instance.ActivateFuel();

        Destroy(gameObject);
    }
}
