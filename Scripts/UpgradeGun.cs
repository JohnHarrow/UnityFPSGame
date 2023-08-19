using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created using the structure I learned from a tutorial and edited a lot to fit what I needed
//https://www.youtube.com/watch?v=zEfahR66Pa8&ab_channel=Gunzz

public class UpgradeGun : MonoBehaviour
{
    public GameObject playerStats;
    public GameObject PickUpText;
    public GameObject weaponHolder;
    public GameObject M4;
    public GameObject AK74;


    // Start is called before the first frame update
    void Start()
    {
        PickUpText.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        /*-------------------- My Code --------------------*/
        playerStats = GameObject.Find("First Person Player");
        PlayerStats stats = playerStats.GetComponent<PlayerStats>();
        weaponHolder = GameObject.Find("WeaponHolder");
        WeaponSwitching gun = weaponHolder.GetComponent<WeaponSwitching>();

        if(other.gameObject.tag == "Player")
        {
            PickUpText.SetActive(true);
            if(Input.GetButton("f"))
            {
                if (stats.points >= 5000f)
                {
                    stats.points -= 5000f;
                    //upgrade current gun damage

                    if (gun.selectedWeapon == 0)
                    {
                        M4 = GameObject.Find("M4_8");
                        Gun m4 = M4.GetComponent<Gun>();
                        m4.damage += 10f;
                        m4.fireRate += 3f;
                        m4.maxAmmo += 10;
                        
                    }
                    if (gun.selectedWeapon == 1)
                    {
                        AK74 = GameObject.Find("AK74");
                        Gun ak74 = AK74.GetComponent<Gun>();
                        ak74.damage += 10f;
                        ak74.fireRate += 3f;
                        ak74.maxAmmo += 10;
                    }

                    PickUpText.SetActive(false);
                }
                
            }
        }
        /*-------------------- My Code --------------------*/
    }

    private void OnTriggerExit(Collider Other)
    {
        PickUpText.SetActive(false);
    }
}
