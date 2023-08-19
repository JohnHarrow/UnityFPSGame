using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created using a tutorial and edited a lot to fit what I needed
//https://www.youtube.com/watch?v=zEfahR66Pa8&ab_channel=Gunzz

public class PickUpSpeed : MonoBehaviour
{
    public GameObject playerStats;
    public GameObject playerMovement;
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
        playerMovement = GameObject.Find("First Person Player");
        PlayerMovement movement = playerStats.GetComponent<PlayerMovement>();
        if(other.gameObject.tag == "Player")
        {
            PickUpText.SetActive(true);
            if(Input.GetButton("f"))
            {
                if (stats.points >= 2000f){
                    stats.points -= 2000f;
                    movement.speed += 3f;
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
