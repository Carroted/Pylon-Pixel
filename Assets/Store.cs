using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Store : MonoBehaviour
{
    public NewBehaviourScript nbs;
    public Image cone;
    public Image strip;
    public Image basee;
    public TMP_Text gold;

    public Sprite antistrip;
    public Sprite regularstrip;
    public Sprite antibase;
    public Sprite regularbase;
    public int frames = 0;
    private bool doframes = true;
    private bool antis;
    private bool antib;

    public GameObject antisLocked;
    public GameObject antibLocked;
    public Sprite nothing;
    void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        nbs = GameObject.FindGameObjectWithTag("Player").GetComponent<NewBehaviourScript>();
        if (PlayerPrefs.HasKey("antistrip"))
        {
            antis = PlayerPrefs.GetInt("antistrip") == 1;
        }
        else
        {
            antis = false;
            PlayerPrefs.SetInt("antistrip", 0);
        }
        if (PlayerPrefs.HasKey("antibase"))
        {
            antib = PlayerPrefs.GetInt("antibase") == 1;
        }
        else
        {
            antib = false;
            PlayerPrefs.SetInt("antibase", 0);
        }
        doframes = true;
    }
    public void ConeColor(Color color)
    {
        cone.color = color;
    }
    public void ShowStrip()
    {
        strip.enabled = true;
    }
    public void HideStrip()
    {
        strip.enabled = false;
    }
    public void ShowBase()
    {
        basee.enabled = true;
    }
    public void HideBase()
    {
        basee.enabled = false;
    }
    public void SetBase(Sprite sprite)
    {
        basee.sprite = sprite;
    }
    public void SetStrip(Sprite sprite)
    {
        strip.sprite = sprite;
    }
    public bool Pay(int price)
    {
        if (nbs.gold >= price)
        {
            nbs.gold -= price;
            PlayerPrefs.SetInt("gold", nbs.gold);
            PlayerPrefs.Save();
            gold.text = nbs.gold.ToString();
            return true;
        }
        return false;
    }
    public void Save()
    {
        PlayerPrefs.SetString("color", ColorUtility.ToHtmlStringRGB(cone.color));
        nbs.cone.color = cone.color;
        if ((strip.sprite == antistrip || strip.sprite == nbs.antistrip) && strip.enabled == true)
        {
            print("strip is anti, using anti lmao");
            PlayerPrefs.SetString("strip", "anti");
            nbs.strip.sprite = strip.sprite;
        }
        else if (!strip.enabled || strip.sprite == nbs.nothing)
        {
            print("strip is disabled, using none lmao");
            PlayerPrefs.SetString("strip", "none");
            nbs.strip.sprite = nothing;
        }
        else if (strip.enabled == true)
        {
            print("strip is enabled, using regular lmao");
            PlayerPrefs.SetString("strip", "regular");
            nbs.strip.sprite = strip.sprite;

        }
        if ((basee.sprite == antibase || basee.sprite == nbs.antibase) && basee.enabled == true)
        {
            print("base is anti, using anti lmao");
            PlayerPrefs.SetString("base", "anti");
            nbs.basee.sprite = basee.sprite;
        }
        else if ((!basee.enabled) || basee.sprite == nbs.nothing)
        {
            print("base is disabled, using none");
            PlayerPrefs.SetString("base", "none");
            nbs.basee.sprite = nothing;
        }
        else if (basee.enabled)
        {
            print("base is enabled, using regular");
            PlayerPrefs.SetString("base", "regular");
            nbs.basee.sprite = basee.sprite;
        }
        PlayerPrefs.Save();
        gameObject.SetActive(false);
    }
    public void Reset()
    {
        strip.sprite = nbs.strip.sprite;
        basee.sprite = nbs.basee.sprite;
        cone.color = nbs.cone.color;
    }
    public void AntiStrip()
    {
        if (!antis)
        {
            // Buy
            if (Pay(700))
            {
                antis = true;
                PlayerPrefs.SetInt("antistrip", 1);
                antisLocked.SetActive(false);


            }
        }
        else
        {
            strip.sprite = antistrip;
        }
    }
    public void RegularBase()
    {

        basee.sprite = regularbase;

    }
    public void AntiBase()
    {
        if (!antib)
        {
            // Buy
            if (Pay(150))
            {
                antib = true;
                PlayerPrefs.SetInt("antibase", 1);
                antibLocked.SetActive(false);
            }
        }
        else
        {
            basee.sprite = antibase;
        }
    }
    // Update is called once per frame
    void Update()
    {
        gold.text = nbs.gold.ToString();
        if (doframes)
        {
            frames++;
            if (frames >= 2)
            {
                strip.sprite = nbs.strip.sprite;
                basee.sprite = nbs.basee.sprite;
                cone.color = nbs.cone.color;
                doframes = false;
                frames = 0;
            }
        }

    }
}
