using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;
using System.Linq;

public class TaggedObjectSensorNotTrigger : MonoBehaviour
{
    public UnityEvent onObjectEnter;
    public UnityEvent onObjectStay;
    public UnityEvent onObjectExit;



    void OnCollisionEnter2D(Collision2D collision)
    {
       
            onObjectEnter.Invoke();
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        
            onObjectStay.Invoke();
    }
    void OnCollisionExit2D(Collision2D collision)
    {
       
            onObjectExit.Invoke();
    }
}