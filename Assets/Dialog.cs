using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class Dialog : MonoBehaviour
{
    public TMP_Text dialog;
    public static bool talking = false;
    public float timer = 0.0f;
    public float delay;
    public int index = 0;
    public string say = "Hello World! Lorem ipsum dolor sit amet.";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (NewBehaviourScript.dialogClose)
        {
            gameObject.SetActive(false);
        }
        string result = string.Join("~", say.AsEnumerable());
        //  Debug.Log();
        //say = say.Replace("", "~");
        string[] testertime = result.Split('~');
        if (index < testertime.Length)
        {
            timer += Time.deltaTime;
            if (timer >= delay)
            {
                dialog.text += testertime[index];
                index++;
                timer = 0.0f;
            }
        }

    }
}
