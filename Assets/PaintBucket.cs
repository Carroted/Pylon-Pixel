using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintBucket : MonoBehaviour
{
    public Color color;
    public int cost;
    public bool unlockedByDefault = false;
    private bool unlocked = false;
    public string id;

    public GameObject lockedStuff;
    public Store store;

    public void Press()
    {
        if (!unlocked)
        {
            // Buy
            if (store.Pay(cost))
            {
                unlocked = true;
                lockedStuff.SetActive(false);

                PlayerPrefs.SetInt(id, 1);
            }
        }
        else
        {
            store.ConeColor(color);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey(id))
        {
            unlocked = PlayerPrefs.GetInt(id) == 1;
        }
        else if (unlockedByDefault)
        {
            PlayerPrefs.SetInt(id, 1);
            unlocked = true;
        }
        else
        {
            PlayerPrefs.SetInt(id, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {

        lockedStuff.SetActive(!unlocked);
    }
}
