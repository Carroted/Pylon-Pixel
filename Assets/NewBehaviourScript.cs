using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using UnityStandardAssets.CrossPlatformInput;
//using XInputDotNetPure;

public class NewBehaviourScript : MonoBehaviour // Pylon must strictly abide by this behaviour.
{
    float deadZone = 0.3f;
    public int debugAddGold = 0;
    public Sprite pyyy;
    public TMPro.TMP_Text goldcount;
    public int gold;
    public bool endless = false;
    public GameObject firefrom;
    public GameObject firefrom2;
    public GameObject firefrom3;
    public SpriteRenderer strip;
    public SpriteRenderer basee;
    public SpriteRenderer cone;
    public bool jumpbtn = false;
    public GameObject projectprefab;
    public GameObject projectprefab2;
    public GameObject projectprefab3;
    public Health hp;
    public SFX sfx;
    public int weapon = 0;
    public GameObject w1;
    public GameObject w2;
    public GameObject w3;
    private int waitahah = 0;
    private bool cansmg = true;
    public bool triggershoot = false;
    float startTime = 0;
    float waitFor = 4;
    bool timerStart = false;
    public Rigidbody2D rb;
    public Transform[] groundChecks;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool onGround;
    public Joystick j;
    public Sprite regularbase;
    public Sprite regularstrip;
    public Sprite antibase;
    public Sprite antistrip;
    public Sprite nothing;
    //public Animator animator;
    //Animator m_Animator;
    public int livess;
    private bool mobileFire2 = false;
    private bool mobileFire3 = false;
    private float vibrationTimer = 0.0f;
    public float vibrationTimerDelay = 0.1f;
    private bool vibrate1 = false;
    private bool vibrate2 = false;
    public static bool dialogClose = false;

    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.HasKey("DeadZoneVolume"))
        {
            deadZone = PlayerPrefs.GetFloat("DeadZoneVolume") / 20;
        }
        else
        {
            PlayerPrefs.SetFloat("DeadZoneVolume", deadZone * 20);
        }
        if (PlayerPrefs.HasKey("color"))
        {
            Color colory;
            ColorUtility.TryParseHtmlString("#" + PlayerPrefs.GetString("color"), out colory);
            cone.color = colory;
        }
        if (PlayerPrefs.HasKey("strip"))
        {
            print(PlayerPrefs.GetString("strip"));
            if (PlayerPrefs.GetString("strip") == "regular")
            {
                strip.sprite = regularstrip;
                print("strip is regular");
            }
            else if (PlayerPrefs.GetString("strip") == "none")
            {
                strip.sprite = nothing;
                print("strip is none");
            }
            else
            {
                strip.sprite = antistrip;
                print("strip is anti");
            }
        }
        else
        {
            print("no strip saved using regular");
            strip.sprite = regularstrip;
            PlayerPrefs.SetString("strip", "regular");
        }
        if (PlayerPrefs.HasKey("base"))
        {
            print(PlayerPrefs.GetString("base"));
            if (PlayerPrefs.GetString("base") == "regular")
            {   // Oh, you know Crystalius? He's... well.. he's a little gullible.
                print("base is regular");
                basee.sprite = regularbase;
            }
            else if (PlayerPrefs.GetString("base") == "none")
            {
                print("base is none");
                basee.sprite = nothing;
            }
            else
            {
                print("base is anti");
                basee.sprite = antibase;
            }
        }
        else
        { // Yeah, I know. I mean, he's cool though. That Will guy on the other hand.. something's... off about him.
            print("no base saved using regular");
            basee.sprite = regularbase;
            PlayerPrefs.SetString("base", "regular");
        }

        dialogClose = false;
        cone.sprite = pyyy;
        sfx = FindObjectOfType<SFX>();
        goldcount = GameObject.FindGameObjectWithTag("goldui").GetComponent<TMPro.TMP_Text>();
        if (!endless)
        {
            if (!PlayerPrefs.HasKey("gold"))
            {
                PlayerPrefs.SetInt("gold", debugAddGold);
            }
            else
            {
                gold = PlayerPrefs.GetInt("gold") + debugAddGold;
            }
        } // What do you mean by that?
        else
        {
            if (!PlayerPrefs.HasKey("egold"))
            {
                PlayerPrefs.SetInt("egold", debugAddGold);
            }
            else
            {
                gold = PlayerPrefs.GetInt("egold") + debugAddGold;
            }
        }// Well, I don't really know. I guess not.

        //whatIsGround = LayerMask.GetMask("jumpable", "otherJump");
        rb = GetComponent<Rigidbody2D>();
        //  m_Animator = gameObject.GetComponent<Animator>();
        livess = 3;
    }
    IEnumerator JumpAnim()
    {

        yield return new WaitForSeconds(2.1F);



    }
    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "healthfruit")
        {
            Destroy(target.gameObject);
            sfx.Play(sfx.healthfruit);
            hp.health += 150f;
        }
        if (target.gameObject.tag == "healthfruit+")
        {
            Destroy(target.gameObject);
            sfx.Play(sfx.healthfruit);
            hp.health += 250f;
        }
        if (target.gameObject.tag == "poison fruit")
        {
            Destroy(target.gameObject);
            sfx.Play(sfx.poisonfruit);
            hp.health -= 150f;
        }

        if (target.gameObject.tag == "gold")
        {


            sfx.Play(sfx.gold);
            gold++;
            if (endless)
            {
                PlayerPrefs.SetInt("egold", gold);
            }
            else
            {
                PlayerPrefs.SetInt(target.gameObject.GetComponent<UniqueId>().uniqueId, 1);
                PlayerPrefs.SetInt("gold", gold);
            }
            Destroy(target.gameObject);
            PlayerPrefs.Save();
        }
        if (target.gameObject.tag == "goldbig")
        {


            sfx.Play(sfx.gold);
            gold += 10;
            if (endless)
            {
                PlayerPrefs.SetInt("egold", gold);
            }
            else
            {
                PlayerPrefs.SetInt(target.gameObject.GetComponent<UniqueId>().uniqueId, 1);
                PlayerPrefs.SetInt("gold", gold);
            }
            Destroy(target.gameObject);
            PlayerPrefs.Save();
        }
    }
    public void Jump()
    {
        jumpbtn = true;
    }
    public void JumpStop()
    {
        jumpbtn = false;
    }

    public void CloseDialog()
    {
        dialogClose = true;
    }
    public void CloseTheCloseDialog()
    {
        dialogClose = false;
    }
    public void Fire()
    {
        if (hp.alive)
        {
            if (weapon == 1)
            {
                sfx.Play(sfx.shoot, 0.2f);
                GameObject project = Instantiate(projectprefab, firefrom.transform.position, Quaternion.identity);

                if (gameObject.transform.localScale.x < 0f)
                {
                    project.GetComponent<projectile>().flipped = true;
                }
            }
            if (weapon == 2)
            {
                mobileFire2 = true;

            }
            if (weapon == 3)
            {
                mobileFire3 = true;
            }
        }
    }
    public void FireStop()
    {
        if (hp.alive)
        {
            if (weapon == 2)
            {
                mobileFire2 = false;

            }
            if (weapon == 3)
            {
                mobileFire3 = false;
            }
        }
    }

    public void Fire2()
    {
        if (hp.alive)
        {
            if (weapon == 2)
            {
                sfx.Play(sfx.shoot, 0.2f);
                GameObject project = Instantiate(projectprefab2, firefrom2.transform.position, Quaternion.identity);

                if (gameObject.transform.localScale.x < 0f)
                {
                    project.GetComponent<projectile>().flipped = true;
                }
            }

        }
    }
    public void Fire3()
    {
        if (hp.alive)
        {
            if (weapon == 3)
            {
                sfx.Play(sfx.shoot, 0.2f);
                GameObject project = Instantiate(projectprefab3, firefrom3.transform.position, Quaternion.identity);

                if (gameObject.transform.localScale.x < 0f)
                {
                    project.GetComponent<projectile>().flipped = true;
                }
            }

        }
    }
    // Update is called once per frame
    public void GiveWeapon(int weaponToGive)
    {
        weapon = weaponToGive;
        if (weaponToGive == 1)
        {
            w1.SetActive(true);
            w2.SetActive(false);
            w3.SetActive(false);
        }
        else if (weaponToGive == 2)
        {
            w1.SetActive(false);
            w2.SetActive(true);
            w3.SetActive(false);
        }
        else if (weaponToGive == 3)
        {
            w1.SetActive(false);
            w2.SetActive(false);
            w3.SetActive(true);
        }
        else
        {
            w1.SetActive(false);
            w2.SetActive(false);
            w3.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        if ((Mathf.Round(Input.GetAxisRaw("Fire1")) > 0 || mobileFire2 || mobileFire3) && cansmg)
        {
            if (hp.alive)
            {
                if (weapon == 2)
                {
                    if (!vibrate2)
                    {
                        // GamePad.SetVibration(0, 0.1f, 0.1f);
                    }
                    vibrate2 = true;
                    Fire2();
                    cansmg = false;
                }
                else if (weapon == 3)
                {
                    if (!vibrate2)
                    {
                        // GamePad.SetVibration(0, 0.1f, 0.1f);
                    }
                    vibrate2 = true;
                    Fire3();
                    cansmg = false;
                }
                else if (!vibrate1)
                {
                    vibrate2 = false;
                    //  GamePad.SetVibration(0, 0f, 0f);
                }
            }
            else if (!vibrate1)
            {
                vibrate2 = false;
                // GamePad.SetVibration(0, 0f, 0f);
            }
        }
        else if ((cansmg && (!(Mathf.Round(Input.GetAxisRaw("Fire1")) > 0 || mobileFire2 || mobileFire3))) && !vibrate1)
        {
            vibrate2 = false;
            // GamePad.SetVibration(0, 0f, 0f);

        }

        waitahah++;
        if (waitahah >= 5)
        {
            cansmg = true;
            waitahah = 0;
        }
    }
    void Update()
    {

        deadZone = PlayerPrefs.GetFloat("DeadZoneVolume") / 20;

        if (Input.GetButtonDown("Dialog"))
        {
            dialogClose = true;
        }
        if (Input.GetButtonUp("Dialog"))
        {
            dialogClose = false;
        }
        if (vibrate1)
        {
            vibrationTimer += Time.deltaTime;
            if (vibrationTimer >= vibrationTimerDelay)
            {
                vibrationTimer = 0f;
                vibrate1 = false;
                // GamePad.SetVibration(0, 0f, 0f);
            }
        }
        goldcount.text = gold.ToString();
        if (hp.alive)
        {
            if (weapon == 1)
            {

                if (Mathf.Round(Input.GetAxisRaw("Fire1")) > 0 && !triggershoot)
                {
                    //GamePad.SetVibration(0, 0.2f, 0.2f);
                    vibrationTimer = 0.0f;
                    vibrate1 = true;
                    sfx.Play(sfx.shoot);
                    triggershoot = true;
                    GameObject project = Instantiate(projectprefab, firefrom.transform.position, Quaternion.identity);
                    if (gameObject.transform.localScale.x < 0f)
                    {
                        project.GetComponent<projectile>().flipped = true;
                    }

                }

                if (Mathf.Round(Input.GetAxisRaw("Fire1")) == 0 && triggershoot)
                {
                    triggershoot = false;

                }


            }
            onGround = false;
            foreach (Transform gc in groundChecks)
            {
                if (Physics2D.OverlapCircle(gc.position, groundCheckRadius, whatIsGround))
                {
                    onGround = true;
                }
            }

            if (Input.GetButton("Jump") || jumpbtn)
            {
                if (onGround)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 5.1f);

                    // m_Animator.SetBool("jumping", true);

                }




            }
            else
            {
                // m_Animator.SetBool("jumping", false);
            }
            rb.freezeRotation = true;
            if (hp.alive)
            {
                if (Input.GetAxisRaw("Horizontal") >= 0.6f || j.Horizontal >= deadZone)
                {


                    rb.velocity = new Vector2(4.1f, rb.velocity.y);
                    gameObject.transform.localScale = new Vector3(1, 1, 1);

                }

                if (Input.GetAxisRaw("Horizontal") <= -0.6f || j.Horizontal <= -deadZone)
                {


                    rb.velocity = new Vector2(-4.1f, rb.velocity.y);
                    gameObject.transform.localScale = new Vector3(-1, 1, 1);

                }


                if (Input.GetKey(KeyCode.Tab))
                {
                    Time.timeScale = 2f;
                }
                else
                {
                    Time.timeScale = 1f;
                }

                if (Input.GetAxisRaw("Vertical") <= -0.6f || j.Vertical <= -deadZone)
                {

                    rb.AddForce(new Vector2(0f, -19f));
                }
            }

        }
        else
        {
            // hp.alive = true;
            NextLevel.Static(true);
            if (PlayerPrefs.HasKey("deaths"))
            {
                PlayerPrefs.SetInt("deaths", PlayerPrefs.GetInt("deaths") + 1);
            }
            else
            {
                PlayerPrefs.SetInt("deaths", 1);
            }
            hp.alive = false;
            hp.health = 0;
            this.enabled = false;
        }
    }
}
