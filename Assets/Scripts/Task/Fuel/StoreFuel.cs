using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreFuel : MonoBehaviour
{

    public string currentFuel = "None";
    public GameObject manager;
    public SpriteRenderer slider;
    public string fuelAccepted = "None";
    public float fillSpeed = 0.01f;
    public float totalFill = 0f;
    public static StoreFuel Instance;

    public GameObject coffee, water, gas;

    private void Awake()
    {
        Instance = this;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentFuel = collision.name;
        switch (fuelAccepted)
        {
            case "Coffee":
                slider.color = new Color(0.4901961f, 0.2784314f, 0);
                break;

            case "Gas":
                slider.color = new Color(0.764706f, 0.7450981f, 0);
                break;

            case "Water":
                slider.color = new Color(0f, 0.7686275f, 0.9960785f);
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (currentFuel == fuelAccepted)
        {
            totalFill += fillSpeed;
            if(totalFill >= 1)
            {
                GameManager.Instance.reset();
                Destroy(manager, 1f);
            }
        }
    }

    public void ActivateFuel() {

        switch (fuelAccepted)
        {
            case "Coffee":
                coffee.SetActive(true);
                break;

            case "Gas":
                gas.SetActive(true);
                break;

            case "Water":
                water.SetActive(true);
                break;
        }

    }


}
