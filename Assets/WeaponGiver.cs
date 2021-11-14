using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGiver : MonoBehaviour
{
    public GameObject weapon1;
    public Inventory inv;
    // public GameObject weapon2;
    public int weaponToGive = 1;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<NewBehaviourScript>().GiveWeapon(weaponToGive);
            weapon1.SetActive(false);
            if (weaponToGive == 1)
            {
                inv.has1 = true;
            }
            if (weaponToGive == 2)
            {
                inv.has2 = true;

            }
            if (weaponToGive == 3)
            {
                inv.has3 = true;

            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
