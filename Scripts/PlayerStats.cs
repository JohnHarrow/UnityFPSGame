using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//This is just the same base code as the Target script but with the regeneration function I created and the extra variables I needed.
//https://www.youtube.com/watch?v=THnivyG0Mvo&ab_channel=Brackeys
//I used a tutorial to create the flashing red screen when the player is hit: https://www.youtube.com/watch?v=d9FaI28Yf9A&ab_channel=Firemind

public class PlayerStats : MonoBehaviour
{
    /*-------------------- My Code --------------------*/
    public float health = 50f;
    public float maxHealth = 50f;
    public float points = 0f;

    public GameObject gotHitScreen;
    /*-------------------- My Code --------------------*/

    void Update()
    {
        /*-------------------- Code from: https://www.youtube.com/watch?v=d9FaI28Yf9A&ab_channel=Firemind --------------------*/
        if (gotHitScreen != null)
        {
            if (gotHitScreen.GetComponent<Image>().color.a > 0)
            {
                var color = gotHitScreen.GetComponent<Image>().color;
                color.a -= 0.01f;
                gotHitScreen.GetComponent<Image>().color = color;
            }
        }
        /*----------------------------------------*/
    }

    public void TakeDamage(float amount)
    {
        FindObjectOfType<AudioManager>().Play("PlayerHit");
        health -= amount;

        /*-------------------- Code from: https://www.youtube.com/watch?v=d9FaI28Yf9A&ab_channel=Firemind --------------------*/
        var color = gotHitScreen.GetComponent<Image>().color;
        color.a = 0.8f;
        gotHitScreen.GetComponent<Image>().color = color;
        /*----------------------------------------*/

        /*-------------------- My Code --------------------*/
        if (health <= 0f)
        {
            Die();
        }
        else
        {
            StartCoroutine(RegenerateHealth());
        }
        /*-------------------- My Code --------------------*/
    }

    void Die()
    {
        Destroy(gameObject);
        /*-------------------- My Code --------------------*/
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene(2);
        /*-------------------- My Code --------------------*/
    }

    /*-------------------- My Code --------------------*/
    IEnumerator RegenerateHealth()
    {
        if (health < maxHealth && health != 0f)
        {
            Debug.Log ("Regenerating Health..");
            yield return new WaitForSeconds(5f);
            health += 10f;
        }
    }
    /*-------------------- My Code --------------------*/
}
