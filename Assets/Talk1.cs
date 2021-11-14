using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk1 : MonoBehaviour
{
    public GameObject you;
    public Rigidbody2D rb;
    public GameObject dialogPrefab;
    public GameObject canvas;
    private GameObject prev;
    public string startMessage;
    private bool dialoging = false;
    static bool close = false;
    public GameObject mus;
    public GameObject battlemus;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        
        //Say("Haha will this work?");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            mus.SetActive(false);
            battlemus.SetActive(true);
            enemy.SetActive(true);
            Say(startMessage);
        }
    }
    public void Say(string talk)
    {
        if(you.GetComponent<Health>().alive)
        {
if(!Dialog.talking)
        {
        GameObject fun = Instantiate(dialogPrefab, canvas.transform);
        Dialog script = fun.GetComponent<Dialog>();
        
        script.say = talk;
        prev = fun;
        dialoging = true;
            Dialog.talking = true;
        }
        }
        
       
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(dialoging)
        {
            System.Random rnd = new System.Random();
            rb.velocity += new Vector2(0f, rnd.Next(-1, 2)); 

        }
       
        //dialogPrefab.GetComponent<Dialog>();
    }
    public static void Close()
    {
        close = true;
    }
    void Update()
    {
        if (dialoging)
        {
           
            if (Input.GetButtonDown("Dialog") || close)
            {
                close = false;
                prev.SetActive(false);
                Dialog.talking = false;
                dialoging = false;
                
                Destroy(gameObject);
            }
        }

        //dialogPrefab.GetComponent<Dialog>();
    }
}
