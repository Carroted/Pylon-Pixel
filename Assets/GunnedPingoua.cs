using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnedPingoua : MonoBehaviour
{
    public Follow script;
    public Health hp;
    public SFX sfx;
    private float timer;
    public float reloadTime = 0.5f;
    public GameObject fire;
    public GameObject proj;
    private Rigidbody2D rb;

    public Transform[] groundChecks;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool onGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
            script.enabled = false;
        
        
        sfx = FindObjectOfType<SFX>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            Health health = collision.GetComponent<Health>();

            if (health != null)
            {
                if(health.alive)
                {
                    if (hp.alive)
                    {
                        script.enabled = true;
                    }

                    script.PingouaIdle = collision.gameObject;
                }
                
            }
            
        }
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer != 8)
        {
            script.enabled = false;
            script.PingouaIdle = collision.gameObject;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hp.alive)
        {
            if (collision.gameObject.tag == "enemy")
            {

                collision.gameObject.GetComponent<Health>().health -= 100;
                sfx.Play(sfx.damage, 0.75f);
            }

        }
    }
    // Update is called once per frame
    void Update()
    {
        onGround = false;
        if (hp.alive)
        {
            
            foreach (Transform gc in groundChecks)
            {
                if (Physics2D.OverlapCircle(gc.position, groundCheckRadius, whatIsGround))
                {
                    onGround = true;
                }
            }
        }
        
        if (!hp.alive)
        {
            script.enabled = false;
        }
        if (script.enabled)
        {
            if (script.PingouaIdle.transform.position.x > transform.position.x)
            {
                gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
            if (script.PingouaIdle.transform.position.x < transform.position.x)
            {
                gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        timer += Time.deltaTime;

        if(timer >= reloadTime)
        {
            
            timer = 0f;

            if(script.enabled)
            {
                sfx.Play(sfx.shoot);
                GameObject project = Instantiate(proj, fire.transform.position, Quaternion.identity);
                if (gameObject.transform.localScale.x < 0f)
                {
                    project.GetComponent<projectile>().flipped = true;
                }
            }
            
        }
        
    }
    private void FixedUpdate()
    {
        if (onGround && Random.Range(0,50) == 5 && hp.alive)
        {
            rb.velocity = new Vector2(rb.velocity.x, 5.1f);
        }
        if (!script.enabled && hp.alive)
        {

            rb.velocity = new Vector2(2f, rb.velocity.y);
        }
    }
}
