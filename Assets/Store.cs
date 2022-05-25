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
    public string hatState;
    public Image hat;
    public Sprite xmasHat;
    public Sprite constructionHat;
    public Sprite headphonesHat;
    public Sprite hoodieHat;
    public Sprite orangeHoodieHat;
    public Sprite carrotedHoodieHat;
    public Sprite smileHat;
    public Sprite mustacheHat;
    public Sprite pylonpixelHoodieHat;
    public Sprite glitchconeHat;
    public Sprite greenoutlineHat;
    public Sprite whiteoutlineHat;
    public Sprite topHat;
    public Sprite redTopHat;
    void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        if (BetterPrefs.HasKey("hat"))
        {
            hatState = BetterPrefs.GetString("hat");
        }
        else
        {
            hatState = "none";
            BetterPrefs.SetString("hat", "none");
        }
        nbs = GameObject.FindGameObjectWithTag("Player").GetComponent<NewBehaviourScript>();
        if (BetterPrefs.HasKey("antistrip"))
        {
            antis = BetterPrefs.GetInt("antistrip") == 1;
        }
        else
        {
            antis = false;
            BetterPrefs.SetInt("antistrip", 0);
        }
        if (BetterPrefs.HasKey("antibase"))
        {
            antib = BetterPrefs.GetInt("antibase") == 1;
        }
        else
        {
            antib = false;
            BetterPrefs.SetInt("antibase", 0);
        }
        doframes = true;
        antisLocked.SetActive(!antis);
        antibLocked.SetActive(!antib);
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
            BetterPrefs.SetInt("gold", nbs.gold);
            BetterPrefs.Save();
            gold.text = nbs.gold.ToString();
            return true;
        }
        return false;
    }
    public void Save()
    {
        BetterPrefs.SetString("color", ColorUtility.ToHtmlStringRGB(cone.color));
        nbs.cone.color = cone.color;
        if ((strip.sprite == antistrip || strip.sprite == nbs.antistrip) && strip.enabled == true)
        {
            print("strip is anti, using anti lmao");
            BetterPrefs.SetString("strip", "anti");
            nbs.strip.sprite = strip.sprite;
        }
        else if (!strip.enabled || strip.sprite == nbs.nothing)
        {
            print("strip is disabled, using none lmao");
            BetterPrefs.SetString("strip", "none");
            nbs.strip.sprite = nothing;
        }
        else if (strip.enabled == true)
        {
            print("strip is enabled, using regular lmao");
            BetterPrefs.SetString("strip", "regular");
            nbs.strip.sprite = strip.sprite;

        }
        if ((basee.sprite == antibase || basee.sprite == nbs.antibase) && basee.enabled == true)
        {
            print("base is anti, using anti lmao");
            BetterPrefs.SetString("base", "anti");
            nbs.basee.sprite = basee.sprite;
        }
        else if ((!basee.enabled) || basee.sprite == nbs.nothing)
        {
            print("base is disabled, using none");
            BetterPrefs.SetString("base", "none");
            nbs.basee.sprite = nothing;
        }
        else if (basee.enabled)
        {
            print("base is enabled, using regular");
            BetterPrefs.SetString("base", "regular");
            nbs.basee.sprite = basee.sprite;
        }
        BetterPrefs.SetString("hat", hatState);
        nbs.hat.sprite = hat.sprite;
        BetterPrefs.Save();
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
                BetterPrefs.SetInt("antistrip", 1);
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
                BetterPrefs.SetInt("antibase", 1);
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
        if (hatState == "none")
        {
            hat.sprite = nothing;
        }
        else if (hatState == "xmasHat")
        {
            hat.sprite = xmasHat;
        }
        else if (hatState == "headphonesHat")
        {
            hat.sprite = headphonesHat;
        }
        else if (hatState == "hoodieHat")
        {
            hat.sprite = hoodieHat;
        }
        else if (hatState == "orangeHoodieHat")
        {
            hat.sprite = orangeHoodieHat;
        }
        else if (hatState == "carrotedHoodieHat")
        {
            hat.sprite = carrotedHoodieHat;
        }
        else if (hatState == "constructionHat")
        {
            hat.sprite = constructionHat;
        }
        else if (hatState == "smileHat")
        {
            hat.sprite = smileHat;
        }
        else if (hatState == "mustacheHat")
        {
            hat.sprite = mustacheHat;
        }
        else if (hatState == "pylonpixelHoodieHat")
        {
            hat.sprite = pylonpixelHoodieHat;
        }
        else if (hatState == "glitchconeHat")
        {
            hat.sprite = glitchconeHat;
        }
        else if (hatState == "greenoutlineHat")
        {
            hat.sprite = greenoutlineHat;
        }
        else if (hatState == "whiteoutlineHat")
        {
            hat.sprite = whiteoutlineHat;
        }
        else if (hatState == "topHat")
        {
            hat.sprite = topHat;
        }
        else if (hatState == "redTopHat")
        {
            hat.sprite = redTopHat;
        }
    }
}
