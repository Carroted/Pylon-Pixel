using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventory;
    public bool has1;
    public bool has2;
    public bool has3;

    public GameObject small1;
    public NewBehaviourScript nbs;
    public GameObject big1;
    public GameObject small2;
    public GameObject big2;
    public GameObject small3;
    public GameObject big3;
    public GameObject small4;
    public GameObject big4;


    public GameObject w1b;
    public GameObject w1s;
    public GameObject w2b;
    public GameObject w2s;
    public GameObject w3b;
    public GameObject w3s;

    // Start is called before the first frame update
    public int which = 2;
    int prev = 2;
    void Start()
    {
        if (nbs == null)
        {
            nbs = GameObject.FindGameObjectWithTag("Player").GetComponent<NewBehaviourScript>();
        }

    }
    public void Lose3()
    {
        has3 = false;
    }
    // Empty
    public void Select1()
    {
        inventory.SetActive(true);

        which = 1;
    }
    // Weapon1
    public void Select2()
    {
        inventory.SetActive(true);

        which = 2;
    }
    // Weapon2
    public void Select3()
    {
        inventory.SetActive(true);

        which = 3;
    }
    // Weapon3
    public void Select4()
    {
        inventory.SetActive(true);

        which = 2;
    }
    // Update is called once per frame
    void Update()
    {
        if (has1)
        {
            w1b.SetActive(true);
            w1s.SetActive(true);
        }
        else
        {
            w1b.SetActive(false);
            w1s.SetActive(false);
        }

        if (has2)
        {
            w2b.SetActive(true);
            w2s.SetActive(true);
        }
        else
        {
            w2b.SetActive(false);
            w2s.SetActive(false);
        }

        if (has3)
        {
            w3b.SetActive(true);
            w3s.SetActive(true);
        }
        else
        {
            w3b.SetActive(false);
            w3s.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            inventory.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            inventory.SetActive(true);

            which = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            inventory.SetActive(true);
            which = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            inventory.SetActive(true);
            which = 3;
        }


        if (Input.GetButtonDown("RB"))
        {
            inventory.SetActive(true);
            which++;
        }
        if (Input.GetButtonDown("LB"))
        {
            inventory.SetActive(true);
            which--;
        }
        if (which < 1)
        {
            which = 1;
        }
        if (which > 3)
        {
            which = 3;
        }


        if (which == 1 && which != prev)
        {
            nbs.GiveWeapon(0);
            big1.SetActive(true);
            small1.SetActive(false);
            big2.SetActive(false);
            small2.SetActive(true);
            big3.SetActive(false);
            small3.SetActive(true);
            small4.SetActive(true);
            big4.SetActive(false);
        }
        if (which == 2 && which != prev)
        {
            if (has1)
            {
                nbs.GiveWeapon(1);
            }
            else if (has3)
            {
                nbs.GiveWeapon(3);
            }
            else
            {
                nbs.GiveWeapon(0);
            }
            big1.SetActive(false);
            small1.SetActive(true);
            big2.SetActive(true);
            small2.SetActive(false);
            big3.SetActive(false);
            small3.SetActive(true);
            small4.SetActive(false);
            big4.SetActive(true);
        }
        if (which == 3 && which != prev)
        {
            if (has2)
            {
                nbs.GiveWeapon(2);
            }
            else
            {
                nbs.GiveWeapon(0);
            }


            big1.SetActive(false);
            small1.SetActive(true);
            big2.SetActive(false);
            small2.SetActive(true);
            big3.SetActive(true);
            small3.SetActive(false);
            small4.SetActive(true);
            big4.SetActive(false);
        }
        prev = which;
    }
}
