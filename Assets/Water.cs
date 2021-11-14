using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public float drag;
    public float angularDrag;
    private float defaultDrag = 0f;
    private float defaultAngularDrag = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.attachedRigidbody != null && !collision.isTrigger)
        {
            
            collision.attachedRigidbody.drag = drag;
            collision.attachedRigidbody.angularDrag = angularDrag;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.attachedRigidbody != null && !collision.isTrigger)
        {
            
            collision.attachedRigidbody.drag = drag;
            collision.attachedRigidbody.angularDrag = angularDrag;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.attachedRigidbody != null && !collision.isTrigger)
        {
            collision.attachedRigidbody.drag = defaultDrag;
            collision.attachedRigidbody.angularDrag = defaultAngularDrag;

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
