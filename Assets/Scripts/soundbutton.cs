using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class soundbutton : MonoBehaviour, IPointerEnterHandler
{

    void Start () {
		Button btn = transform.GetComponent<Button>();
		btn.onClick.AddListener(onClick);
	}

    // Start is called before the first frame update
    public void OnPointerEnter(PointerEventData eventData){
        SoundManager.Instance.PlaySound("uihover");
    }

    // Update is called once per frame
    void onClick()
    {
        SoundManager.Instance.PlaySound("uiclick");
    }
}
