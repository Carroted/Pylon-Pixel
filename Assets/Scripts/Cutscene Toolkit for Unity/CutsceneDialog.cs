using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneDialog : MonoBehaviour
{
    [Tooltip("Unity AnimationEvents are hard to use. They call methods in code, but we have a better solution. In animation, set this to true. This will show dialog, and automatically set back to false so you can set it again.")]
    public bool show;
    public bool hide;
    [Tooltip("You can animate this to show different dialog at different times in cutscenes.")]
    public string text;

    /*

    !!!!!!!!!!!!!!

    ALL PAST HERE IS AN IMPLEMENTATION, YOU WILL NEED TO MODIFY THIS FOR YOUR OWN PROJECTS, UNLESS THEY USE THE SAME CUTSCENE SYSTEM AS PYLON PIXEL. THIS SERVES AS AN EXAMPLE OF HOW YOU CAN USE CUTSCENEDIALOG.

    !!!!!!!!!!!!!!

    */

    [Tooltip("Uses a random force to make the speaker move around while talking. This can save time instead of manually animating, but can result in the speaker flying away or falling over.")]
    public bool unstable = false;

    public GameObject speaker;
    public new Rigidbody2D rigidbody;
    public GameObject dialogPrefab;
    private GameObject canvas;
    private GameObject previousDialog;
    private bool dialoging = false;

    // Start is called before the first frame update
    void Start()
    {
        // Get the canvas, remove this if you want to set it manually, in which case also set the canvas variable to public and set the canvas in the inspector.
        canvas = GameObject.FindGameObjectWithTag("Canvas");
    }

    public void Say(string talk)
    {
        show = false;
        // If the speaker is alive.
        if (speaker.GetComponent<Health>().alive)
        {
            // Create a new dialog.
            show = false;
            if (!Dialog.talking)
            {
                GameObject dialog = Instantiate(dialogPrefab, canvas.transform);
                Dialog script = dialog.GetComponent<Dialog>();

                script.say = talk;
                previousDialog = dialog;
                dialoging = true;
                Dialog.talking = true;
            }
            else
            {
                // If talking, remove the previous dialog and create a new one.
                if (previousDialog != null)
                {
                    previousDialog.SetActive(false);
                }
                GameObject dialog = Instantiate(dialogPrefab, canvas.transform);
                Dialog script = dialog.GetComponent<Dialog>();

                script.say = talk;
                previousDialog = dialog;
                dialoging = true;
                Dialog.talking = true;
            }
        }
        show = false;
        show = false;
        show = false;
    }

    void FixedUpdate()
    {
        if (dialoging && unstable)
        {
            System.Random rnd = new System.Random();
            rigidbody.velocity += new Vector2(0f, rnd.Next(-1, 2));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (dialoging)
        {
            if (hide)
            {
                hide = false;
                previousDialog.SetActive(false);
                Dialog.talking = false;
                dialoging = false;
            }
        }
        if (dialoging)
        {
            if (show)
            {
                show = false;
                previousDialog.SetActive(false);
                Dialog.talking = false;
                dialoging = false;
                Say(text);
            }
        }
        else
        {
            if (show)
            {
                show = false;
                Say(text);
            }
        }
    }
}
