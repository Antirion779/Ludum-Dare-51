using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class microOndes : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if ((transform.parent.GetComponent<microwaveState>().is_open && !transform.parent.GetComponent<microwaveState>().is_filed && transform.parent.parent.GetComponent<MicroOndesManager>().is_first_task) || (transform.parent.GetComponent<microwaveState>().is_filed && !transform.parent.parent.GetComponent<MicroOndesManager>().is_first_task ) && (other != null)){
            if (!transform.parent.parent.GetComponent<MicroOndesManager>().is_first_task){
                StartCoroutine(transform.parent.parent.GetComponent<MicroOndesManager>().finish_task());
                transform.parent.GetComponent<microwaveState>().is_filed = false;
            }else{
                transform.parent.GetComponent<microwaveState>().is_filed = true;
            }
            other.GetComponent<DragObject>().canBeDrag = false;
            other.gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            other.gameObject.transform.rotation = Quaternion.identity;
            other.GetComponent<Rigidbody2D>().simulated = false;
        }
    }
}
