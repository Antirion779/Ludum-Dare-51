using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroOndesManager : MonoBehaviour
{
    public GameObject bg;
    public GameObject cup;
    public GameObject microWave;
    public GameObject microWaveArea;
    public BoxCollider2D BC;

    public float colorSpeed = 0.01f;

    bool is_active = false;
    bool is_zoom = false;
    bool need_wait = false;
    SpriteRenderer bg_rend;
    microwaveState MCWState;

    void Start(){
        bg_rend = bg.GetComponent<SpriteRenderer>();
        MCWState = microWave.GetComponent<microwaveState>();
        Reset();
        gameObject.SetActive(true);
        is_active = true;
    }

    void Reset(){
        BC.enabled = true;
        is_active = false;
        is_zoom = false;
        gameObject.SetActive(false);
        need_wait = false;

        Color tempColor = bg_rend.color;
        tempColor.a = 1.0f;
        bg_rend.color = tempColor;

        Set_active(false);
    }

    private void OnMouseDown(){
        if (is_active){
            if (!is_zoom){
                if (!need_wait){                
                    need_wait = true;
                    BC.enabled = false;
                }
            }
        }
    }
    // Update is called once per frame
    void Update(){
        if (is_active){
            if (!is_zoom){
                if (need_wait){

                    Color tempColor = bg_rend.color;
                    tempColor.a -= colorSpeed;
                    bg_rend.color = tempColor;
                    if (tempColor.a <= 0.0f){
                        need_wait = false;
                        is_zoom = true;
                        Set_active();
                    }
                }
            }else{
                if ((!MCWState.is_open) && MCWState.is_filed){
                    StartCoroutine(finish_task());
                }
            }
        }
    }

    void Set_active(bool b = true){
        cup.GetComponent<DragObjectReal>().canBeDrag = b;
        MCWState.is_active = b;
    }

    IEnumerator finish_task(){
        Set_active(false);
        yield return new WaitForSeconds(0.5f);
        Reset();
    }
}
