using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteEnemy : MonoBehaviour
{
    public float speed = 1f;
    public int jumprareness = 100;
    public bool move = false;
    public Health hp;
    public SFX sfx;
    private float timer;
    public float reloadTime = 0.5f;
    public GameObject fire;
    public GameObject proj;

    public Rigidbody2D rb;

    public Transform[] groundChecks;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool onGround;
    private GameObject follow;



    // Start is called before the first frame update
    void Start()
    {




        sfx = FindObjectOfType<SFX>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "other")
        {
            if (collision.gameObject.tag == "Player")
            {
                NewBehaviourScript nbs = collision.gameObject.GetComponent<NewBehaviourScript>();
                if ((((nbs.cone.color == Color.white || nbs.cone.color == new Color(22, 22, 22)) || ((nbs.cone.color.r == nbs.cone.color.g) && (nbs.cone.color.r == nbs.cone.color.b))) && nbs.strip.sprite == nbs.antistrip))
                    return; ;
            }
            if (hp.alive)
            {
                move = true;
            }

            follow = collision.gameObject;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer != 8)
        {
            move = false;

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hp.alive)
        {
            if (collision.gameObject.tag == "Player")
            {

                NewBehaviourScript nbs = collision.gameObject.GetComponent<NewBehaviourScript>();
                if ((((nbs.cone.color == Color.white || nbs.cone.color == new Color(22, 22, 22)) || ((nbs.cone.color.r == nbs.cone.color.g) && (nbs.cone.color.r == nbs.cone.color.b))) && nbs.strip.sprite == nbs.antistrip))
                    return;

                collision.gameObject.GetComponent<Health>().health -= 100;
                sfx.Play(sfx.playerGetDamage, 0.75f);
            }
            if (collision.gameObject.tag == "other")
            {
                collision.gameObject.GetComponent<Health>().health -= 100f;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!hp.alive)
        {
            move = false;
        }
        if (move && hp.alive)
        {
            if (follow.transform.position.x > transform.position.x)
            {
                gameObject.transform.localScale = new Vector3(1, 1, 1);
                rb.velocity = new Vector2(2.1f * speed, rb.velocity.y);
            }
            if (follow.transform.position.x < transform.position.x)
            {
                gameObject.transform.localScale = new Vector3(-1, 1, 1);
                rb.velocity = new Vector2(-2.1f * speed, rb.velocity.y);
            }


        }
        if (move && hp.alive)
        {
            onGround = false;


            foreach (Transform gc in groundChecks)
            {
                if (Physics2D.OverlapCircle(gc.position, groundCheckRadius, whatIsGround))
                {
                    onGround = true;
                }
            }

            if (onGround && Random.Range(0, jumprareness) == 1)
            {
                rb.velocity = new Vector2(rb.velocity.x, 5.1f);
            }
        }
        timer += Time.deltaTime;

        if (timer >= reloadTime)
        {

            timer = 0f;

            if (move && hp.alive)
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
}
