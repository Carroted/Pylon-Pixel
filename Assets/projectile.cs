using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public bool flipped = false;
    public float timer = 0f;
    public SFX sfx;
    public int multiplier = 1;
    // Start is called before the first frame update
    void Start()
    {
        sfx = FindObjectOfType<SFX>();
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {

            enemy eenemy = collision.transform.gameObject.GetComponent<enemy>();
            NewBehaviourScript nbs = collision.transform.gameObject.GetComponent<NewBehaviourScript>();
        EliteEnemy elite = collision.transform.gameObject.GetComponent<EliteEnemy>();
        if (eenemy != null)
            {
            if(sfx != null)
            {
                sfx.Play(sfx.damage, 1f);
            }


            
            eenemy.hp.health -= 10 * multiplier;
                gameObject.SetActive(false);

            }

        if (elite != null)
        {
            if (sfx != null)
            {
                sfx.Play(sfx.damage, 1f);
            }

            elite.hp.health -= 10 * multiplier;
            gameObject.SetActive(false);

        }

        if (nbs != null)
        {
            if (sfx != null)
            {
                sfx.Play(sfx.playerGetDamage, 1f);
            }

            nbs.hp.health -= 10 * multiplier;
            gameObject.SetActive(false);

        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        sfx.Play(sfx.hit, 0.7f);
        print(collision.gameObject.name);
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if(!flipped)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(15, 0);
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-15, 0);
        }
    }
}
