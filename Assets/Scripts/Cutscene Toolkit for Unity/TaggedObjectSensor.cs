using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;
using System.Linq;

public class TaggedObjectSensor : MonoBehaviour
{
    public UnityEvent onObjectEnter;
    public UnityEvent onObjectStay;
    public UnityEvent onObjectExit;

    public string[] tags = new string[] { };

    void OnTriggerEnter2D(Collider2D other)
    {
        if (tags.Length == 0)
            return;

        if (tags.Contains(other.tag))
            onObjectEnter.Invoke();
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (tags.Length == 0)
            return;

        if (tags.Contains(other.tag))
            onObjectStay.Invoke();
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (tags.Length == 0)
            return;

        if (tags.Contains(other.tag))
            onObjectExit.Invoke();
    }
}