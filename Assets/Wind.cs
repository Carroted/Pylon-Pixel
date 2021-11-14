using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public float speed;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.attachedRigidbody != null && !collision.isTrigger)
        {

            collision.attachedRigidbody.AddForce(transform.TransformDirection(new Vector2(0, speed * collision.attachedRigidbody.mass)), ForceMode2D.Force);
            
        }
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
