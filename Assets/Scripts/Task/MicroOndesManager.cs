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

    public Vector2 pos_task_1 = new Vector3(0.7f, -2.1f);
    public Vector2 pos_task_2 = new Vector3(-3.8f, -2.3f);

    public Sprite dezoom_cup;
    public Sprite dezoom;

    public float colorSpeed = 0.01f;
    public bool is_first_task = true;

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
        if (is_first_task){
            bg_rend.sprite = dezoom_cup;
            microWaveArea.transform.position = pos_task_1;
            MCWState.Reset();
            MCWState.is_open = false;
        }else{
            bg_rend.sprite = dezoom;
            microWaveArea.transform.position = pos_task_2;
        }
        cup.GetComponent<Rigidbody2D>().simulated = true;
        microWave.GetComponent<BoxCollider2D>().enabled = true;
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
                if (is_first_task){
                    if ((!MCWState.is_open) && MCWState.is_filed){
                        StartCoroutine(finish_task());
                    }
                }
            }
        }
    }

    void Set_active(bool b = true){
        cup.GetComponent<DragObjectReal>().canBeDrag = b;
        MCWState.is_active = b;
    }

    public IEnumerator finish_task(){
        Set_active(false);

        is_first_task = !is_first_task;
        yield return new WaitForSeconds(2.0f);
        Reset();
        gameObject.SetActive(true);
        is_active = true;
    }
}
