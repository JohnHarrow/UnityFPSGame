using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    //https://www.youtube.com/watch?v=ptTTsjXEnj0&ab_channel=SingleSaplingGames
    //Basic code for displaying stats got from this video: everything other than taking the structure |"points.text = stats.points.ToString();"| was coded by me.

/*-------------------- My Code --------------------*/

    [SerializeField] Text healthAmount, currentAmmo, waveNumber, points;
    public GameObject playerStats;
    public GameObject gm;
    public GameObject weaponHolder;
    public GameObject M4;
    public GameObject AK74;

    // Start is called before the first frame update
    void Update()
    {
        playerStats = GameObject.Find("First Person Player");
        PlayerStats stats = playerStats.GetComponent<PlayerStats>();

        gm = GameObject.Find("GM");
        WaveSpawner waveSpawner = gm.GetComponent<WaveSpawner>();

        weaponHolder = GameObject.Find("WeaponHolder");
        WeaponSwitching gun = weaponHolder.GetComponent<WeaponSwitching>();


        healthAmount.text = stats.health.ToString();
        waveNumber.text = waveSpawner.waveName.ToString();
        points.text = stats.points.ToString();

        //Changes the ammo value that is displayed depending on which gun is currently equiped.
        if (gun.selectedWeapon == 0)
        {
            M4 = GameObject.Find("M4_8");
            Gun m4 = M4.GetComponent<Gun>();
            currentAmmo.text = m4.currentAmmo.ToString() + "/" + m4.totalAmmo.ToString();
        }

        if (gun.selectedWeapon == 1)
        {
            AK74 = GameObject.Find("AK74");
            Gun ak74 = AK74.GetComponent<Gun>();
            currentAmmo.text = ak74.currentAmmo.ToString() + "/" + ak74.totalAmmo.ToString();
        }
    }
/*-------------------- My Code --------------------*/
}
