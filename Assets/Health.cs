using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    public Rigidbody2D rb;
 
    public float health = 20f;
    public float max = 20f;
    public FillNSlider fns;
    public Image fill;
    public Slider healthbar;
    public bool alive = true;
    // Start is called before the first frame update
    void Start()
    {
        if(fns != null)
        {
            fns = GameObject.FindGameObjectWithTag("Canvas").GetComponent<FillNSlider>();
          //  print("yeet");
            fill = fns.fill;
            healthbar = fns.slider;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(alive && (collision.relativeVelocity.magnitude / 10) > 10f)
        {
 health -= collision.relativeVelocity.magnitude / 10;
            if(collision.gameObject.tag == "fire")
            {
                health -= collision.relativeVelocity.magnitude / 10;
                health -= collision.relativeVelocity.magnitude / 10;
            }
        }
       
        
    }
    // Update is called once per frame
    void Update()
    {
        if(alive)
        {
 if (health >= max)
        {
               
                    healthbar.gameObject.SetActive(false);
               
            
        }
        else
        {
            healthbar.gameObject.SetActive(true);
        }
        if (health > max)
        {
            health = max;
        }
        if (health <= 0f)
        {
            fill.enabled = false;
            health = 0f;
                alive = false;
        }
            else
            {
                fill.enabled = true;

            }
            healthbar.value = health;
        }
        else
        {
            //alive = false;
            healthbar.gameObject.SetActive(true);
            fill.enabled = false;
            health = 0f;
        }
    }
}
