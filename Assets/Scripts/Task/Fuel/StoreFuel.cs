using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreFuel : MonoBehaviour
{

    public string currentFuel = "None";
    public GameObject manager;
    public Slider slider;
    public Image fillColor;
    public TextMeshProUGUI text;
    public float fillSpeed = 0.01f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentFuel = collision.name;
        switch (text.text)
        {
            case "Coffee":
                fillColor.color = new Color(0.4901961f, 0.2784314f, 0);
                break;

            case "Gas":
                fillColor.color = new Color(0.764706f, 0.7450981f, 0);
                break;

            case "Water":
                fillColor.color = new Color(0f, 0.7686275f, 0.9960785f);
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (currentFuel == text.text)
        {
            slider.value += fillSpeed;
            if(slider.value >= 1)
            {
                Destroy(manager, 1f);
            }
        }
    }


}
