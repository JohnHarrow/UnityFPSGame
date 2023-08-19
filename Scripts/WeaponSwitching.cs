using UnityEngine;
using System.Collections;

//https://www.youtube.com/watch?v=Dn_BUIVdAPg&ab_channel=Brackeys
//All of this code was taken from the tutorial, it works exactly how I wanted and the only thing necessary to change is the number of weapons

public class WeaponSwitching : MonoBehaviour
{

    public int selectedWeapon = 0;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        
        int previousSelectedWeapon = selectedWeapon;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else      
                selectedWeapon++;
                
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
                selectedWeapon = transform.childCount - 1;
            else
                selectedWeapon--;
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform. childCount >= 2)
        {
            selectedWeapon = 1;
        }

        /*if (Input.GetKeyDown(KeyCode.Alpha3) && transform. childCount >= 3)
        {
            selectedWeapon = 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && transform. childCount >= 4)
        {
            selectedWeapon = 3;
        }*/

        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }

    void SelectWeapon() 
    {
        StartCoroutine(SwapAnimation());
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
        
    }
    /*-------------------- My Code --------------------*/
    IEnumerator SwapAnimation()
    {
        animator.SetBool("Swaping", true);
        yield return new WaitForSeconds(.005f);
        animator.SetBool("Swaping", false);
        yield return new WaitForSeconds(.005f);
        
    }
    /*-------------------- My Code --------------------*/
}


