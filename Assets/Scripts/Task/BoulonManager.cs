using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulonManager : MonoBehaviour
{
    public GameObject capot;
    SpriteRenderer imageCapot;
    public GameObject circuit;
    public GameObject boulon;

    public bool is_active = false;
    public bool is_uncap = false;
    public float NBTurn = 5.0f;
    public bool need_wait = false;
    public float colorSpeed = 0.01f;
    public Vector2 targetPoint = Vector2.zero;
    
    float nb_turn = 0.0f;

    Vector2 last_vect = Vector2.zero;
    float angle = 0.0f;
    bool was_pressed = false;
    

    // Start is called before the first frame update
    void Start()
    {
        imageCapot = capot.gameObject.GetComponent<SpriteRenderer>();
        Reset();
        //is_active = true;
    }

    void Reset()
    {
        is_active = false;
        is_uncap = false;
        need_wait = false;
        nb_turn = 0.0f;

        last_vect = Vector2.zero;
        angle = 0.0f;

        Color tempColor = imageCapot.color;
        tempColor.a = 1.0f;
        imageCapot.color = tempColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (is_active){
            if (is_uncap){
                if (!need_wait){
                    if (Input.GetMouseButton(0)){
                        Vector2 mousePoint = Input.mousePosition;
                        mousePoint -= new Vector2(Screen.width/2,Screen.height/2);
                        if (mousePoint != targetPoint){
                            Vector2 newVector = mousePoint - targetPoint;
                            if (was_pressed && newVector != last_vect){
                                float newAngle = Vector2.Angle(newVector,last_vect);
                                Vector3 cross = Vector3.Cross(newVector, last_vect);
                                if (cross.z > 0){
                                    angle += newAngle;
                                }else{
                                    angle -= newAngle;
                                }
                                boulon.transform.eulerAngles = - Vector3.forward * angle;
                                nb_turn = angle/360;
                            }
                            last_vect = newVector;
                            was_pressed = true; 

                        }
                        Debug.DrawRay(transform.position, last_vect, Color.blue);
                    }else if (Input.GetMouseButtonUp(0)){
                        last_vect = Vector2.zero;
                        was_pressed = false;
                    }
                    if (nb_turn >= NBTurn){
                        Reset();
                        gameObject.SetActive(false);
                    }
                }else{
                    //disapear
                }
            }else{
                if (!need_wait){
                    if (Input.GetMouseButtonDown(0)){                    
                        need_wait = true;
                    }
                }else{
                    Color tempColor = imageCapot.color;
                    tempColor.a -= colorSpeed;
                    imageCapot.color = tempColor;
                    if (tempColor.a <= 0.0f){
                        need_wait = false;
                        is_uncap = true;
                    }
                }
            }
        }
    }
}
