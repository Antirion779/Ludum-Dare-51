using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    public float NBTurn = 5.0f;

    public Vector2 targetPoint = Vector2.zero;

    public float nb_turn = 0.0f;

    Vector2 last_vect = Vector2.zero;
    float angle = 0.0f;
    bool was_pressed = false;

    public Sprite coffeeShooterOff, coffeeShooterOn, fullCoffee;
    public SpriteRenderer coffeeShooter, coffeeCup;

    public GameObject manager;

    public bool complete = false;


    private void Update()
    {

        if (complete) return;

        if (Input.GetMouseButton(0))
        {
            Vector2 mousePoint = Input.mousePosition;
            mousePoint -= new Vector2((Screen.width / 2) - 200, Screen.height / 2);
            if (mousePoint != targetPoint)
            {
                Vector2 newVector = mousePoint - targetPoint;
                if (was_pressed && newVector != last_vect)
                {
                    float newAngle = Vector2.Angle(newVector, last_vect);
                    Vector3 cross = Vector3.Cross(newVector, last_vect);
                    if (cross.z > 0)
                    {
                        angle += newAngle;
                    }
                    else
                    {
                        angle -= newAngle;
                    }
                    transform.eulerAngles = -Vector3.forward * angle;
                    if(angle >= 360)
                    {
                        angle -= 360;
                        nb_turn++;
                        StartCoroutine(PlayCoffeeAnimation());
                    } else if(angle < 0)
                    {
                        angle = 0;
                    }
                }
                last_vect = newVector;
                was_pressed = true;

            }
            Debug.DrawRay(transform.position, last_vect, Color.blue);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            last_vect = Vector2.zero;
            was_pressed = false;
        }
        if (nb_turn >= NBTurn)
        {
            coffeeCup.sprite = fullCoffee;
            StartCoroutine(WaitBeforeRemove());
        }
    }

    IEnumerator PlayCoffeeAnimation()
    {
        coffeeShooter.sprite = coffeeShooterOn;
        yield return new WaitForSeconds(0.2f);
        coffeeShooter.sprite = coffeeShooterOff;
    }

    IEnumerator WaitBeforeRemove()
    {
        complete = true;
        yield return new WaitForSeconds(1f);
        manager.SetActive(false);
    }


}
