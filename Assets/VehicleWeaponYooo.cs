using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleWeaponYooo : MonoBehaviour
{
    public GameObject spawn;
    public GameObject projectile;
    public SFX sfx;
    public bool use = false;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void Fire()
    {
        GameObject projectileInstance = Instantiate(projectile, spawn.transform.position, Quaternion.identity);
        projectileInstance.GetComponent<projectile>().flipped = true;
        sfx.Play(sfx.shoot, 0.2f);
    }
    // Update is called once per frame
    void Update()
    {
        if (Mathf.Round(Input.GetAxisRaw("Fire1")) > 0 && !use)
        {
            Fire();
            use = true;
        }
        if (Mathf.Round(Input.GetAxisRaw("Fire1")) == 0)
        {
            use = false;
        }
    }
}
