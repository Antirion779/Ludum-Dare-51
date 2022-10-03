using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class microOndes : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (transform.parent.GetComponent<microwaveState>().is_open && (!transform.parent.GetComponent<microwaveState>().is_filed) && (other != null)){
            other.GetComponent<DragObjectReal>().canBeDrag = false;
            other.gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            other.gameObject.transform.rotation = Quaternion.identity;
            other.GetComponent<Rigidbody2D>().simulated = false;
            transform.parent.GetComponent<microwaveState>().is_filed = true;
        }
    }

}
