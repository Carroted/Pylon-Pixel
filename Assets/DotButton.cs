using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Dot button (fire) for mobile devices
public class DotButton : EventTrigger
{
    public NewBehaviourScript nbs;
    // Start is called before the first frame update
    void Start()
    {
        nbs = FindObjectOfType<NewBehaviourScript>();
    }
    public override void OnPointerDown(PointerEventData data)
    {
        nbs.Fire();
    }
    public override void OnPointerUp(PointerEventData data)
    {
        nbs.FireStop();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
