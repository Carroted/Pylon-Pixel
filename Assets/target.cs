using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{

    private NewBehaviourScript nbs;
    private SFX sfx;
    // Start is called before the first frame update
    void Start()
    {
        sfx = FindObjectOfType<SFX>();
        nbs = FindObjectOfType<NewBehaviourScript>();
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        nbs.gold++;
        sfx.Play(sfx.gold);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
