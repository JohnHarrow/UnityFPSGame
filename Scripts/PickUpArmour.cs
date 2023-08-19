using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created using a tutorial and edited a lot to fit what I needed
//https://www.youtube.com/watch?v=zEfahR66Pa8&ab_channel=Gunzz

public class PickUpArmour : MonoBehaviour
{

    public GameObject playerStats;
    public GameObject PickUpText;

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
        if(other.gameObject.tag == "Player")
        {
            PickUpText.SetActive(true);
            if(Input.GetButton("f"))
            {
                if (stats.points >= 2500f){
                    stats.points -= 2500f;
                    stats.maxHealth += 20f;
                    stats.health = stats.maxHealth;
                    this.gameObject.SetActive(false);
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
