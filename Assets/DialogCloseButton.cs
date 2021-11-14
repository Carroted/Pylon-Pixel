using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DialogCloseButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private NewBehaviourScript nbs;
    // Start is called before the first frame update
    void Start()
    {
        nbs = GameObject.FindGameObjectWithTag("Player").GetComponent<NewBehaviourScript>();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        nbs.CloseTheCloseDialog();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        nbs.CloseDialog();
    }
}
