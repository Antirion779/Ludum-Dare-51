using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class microwaveState : MonoBehaviour
{
    public bool is_active = false;
    public Sprite closed;
    public Sprite open;
    public Sprite closed_filed;
    public SpriteRenderer sprtRdr;
    public BoxCollider2D BC;
    
    public bool is_filed = false;
    public bool is_open = false;

    public void Reset(){
        sprtRdr.sprite = closed;
    }

    private void OnMouseDown(){
        if (is_active){
            is_open = !is_open;
            if (!is_filed){
                if (is_open){
                    sprtRdr.sprite = open;  
                }else{
                    sprtRdr.sprite = closed;
                }
            }else{
                if (is_open){
                    sprtRdr.sprite = open;
                    transform.parent.GetComponent<MicroOndesManager>().cup.SetActive(true);
                    if (!transform.parent.GetComponent<MicroOndesManager>().is_first_task){
                        transform.parent.GetComponent<MicroOndesManager>().cup.GetComponent<DragObjectReal>().canBeDrag = true;
                        transform.parent.GetComponent<MicroOndesManager>().cup.GetComponent<Rigidbody2D>().simulated = true;
                        BC.enabled = false;
                    }
                }else{
                    sprtRdr.sprite = closed_filed;
                    transform.parent.GetComponent<MicroOndesManager>().cup.SetActive(false);
                }
            }
        }
    }
}
