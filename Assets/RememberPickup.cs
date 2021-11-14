using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RememberPickup : MonoBehaviour
{
    public UniqueId uniqueId;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey(uniqueId.uniqueId))
        {
            if (PlayerPrefs.GetInt(uniqueId.uniqueId) == 1)
            {
                gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
