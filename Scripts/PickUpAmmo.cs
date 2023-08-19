using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created using PickUpSpeed script as a starting point and edited to fit what I needed.
public class PickUpAmmo : MonoBehaviour
{
    /*-------------------- My Code --------------------*/
    public GameObject playerStats;
    public GameObject PickUpText;
    public GameObject weaponHolder;
    public GameObject M4;
    public GameObject AK74;
    public bool hasBought = false;
    /*-------------------- My Code --------------------*/

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
            if(Input.GetButtonDown("f") && stats.points >= 500f)
            {
                if (hasBought == false)
                {
                    stats.points -= 500f;
                    if (gun.selectedWeapon == 0)
                    {
                        M4 = GameObject.Find("M4_8");
                        Gun m4 = M4.GetComponent<Gun>();
                        m4.totalAmmo += 250;
                    }

                    if (gun.selectedWeapon == 1)
                    {
                        AK74 = GameObject.Find("AK74");
                        Gun ak74 = AK74.GetComponent<Gun>();
                        ak74.totalAmmo += 250;
                    }
                    hasBought = true;
                }
                    
                    //this.gameObject.SetActive(false);
                    //PickUpText.SetActive(false);
            }
        }
        /*-------------------- My Code --------------------*/
    }

    private void OnTriggerExit(Collider Other)
    {
        PickUpText.SetActive(false);
        hasBought = false;
    }
}
