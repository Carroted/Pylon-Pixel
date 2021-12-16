using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

// Dot button (fire) for mobile devices
public class DotButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public NewBehaviourScript nbs;
    public UnityEvent onDotDown;
    public UnityEvent onDotUp;
    void Start()
    {
        nbs = FindObjectOfType<NewBehaviourScript>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        onDotDown.Invoke();
        nbs.Fire();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        onDotUp.Invoke();
        nbs.FireStop();
    }
}