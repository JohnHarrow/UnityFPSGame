using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//https://www.youtube.com/watch?v=THnivyG0Mvo&ab_channel=Brackeys
//https://www.youtube.com/watch?v=kAx5g9V5bcM&ab_channel=Brackeys
//I created this script while following the two above tutorials.
//I added all the functionality that allow for more damage if the head collider is hit

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;

    public int maxAmmo = 10;
    public int currentAmmo;
    public int totalAmmo = 90;
    public float reloadTime = 1f;
    private bool isReloading = false;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffectZombie;
    public GameObject impactEffect;

    private float nextTimeToFire = 0f;

    public Animator animator;

    void Start()
    {
        currentAmmo = maxAmmo;
    }

    void OnEnable ()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }


    // Update is called once per frame
    void Update()
    {
        if (isReloading)
            return;
        
        if (currentAmmo <= 0)
        {
            /*-------------------- My Code --------------------*/
            if (totalAmmo == 0){
                return;
            }
            else
            {
                StartCoroutine(Reload());
                return;
            }
            /*-------------------- My Code --------------------*/
        }
        /*-------------------- My Code --------------------*/
        if (Input.GetButton("r") && currentAmmo != maxAmmo)
        {
            if (totalAmmo == 0){
                return;
            }
            else
            {
                StartCoroutine(Reload());
                return;
            }
        }
        /*-------------------- My Code --------------------*/
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire) 
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }


    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log ("Reloading..");
        FindObjectOfType<AudioManager>().Play("Reload");

        animator.SetBool("Reloading", true);
        yield return new WaitForSeconds(reloadTime - .25f);
        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(.25f);
        /*-------------------- My Code --------------------*/
        //Checks to see if the current ammo and the total ammo put totgether is less than 30 so that when the loop starts it wont crash the game.
        if ((currentAmmo + totalAmmo) < 30)
        {
            currentAmmo += totalAmmo;
            totalAmmo = 0;
        }
        else
        {
            //Adds ammo one at a time
            while (currentAmmo != maxAmmo) 
            {
                if (totalAmmo != 0)
                {
                    currentAmmo += 1;
                    totalAmmo -= 1;
                };
            }
        }
        /*-------------------- My Code --------------------*/
        isReloading = false;
    }

    void Shoot ()
    {
        /*-------------------- My Code --------------------*/
        muzzleFlash.Play();
        StartCoroutine(ShootAnimation());
        FindObjectOfType<AudioManager>().Play("Gun1");
        /*-------------------- My Code --------------------*/

        currentAmmo--;

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            EnemyStats stats = hit.transform.GetComponent<EnemyStats>();
            if (stats != null)
            {
                /*-------------------- My Code --------------------*/
                FindObjectOfType<AudioManager>().Play("EnemyHit");
                stats.TakeDamage(damage);
                GameObject impactGO = Instantiate(impactEffectZombie, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 0.25f);
                
            }
            else if (hit.transform.name == "Z_Head"){
                FindObjectOfType<AudioManager>().Play("Headshot");
                Debug.Log("Head hit");
                EnemyStats headshotStats = hit.transform.parent.GetComponent<EnemyStats>();
                headshotStats.TakeDamage(damage * 2f);
                GameObject impactGO = Instantiate(impactEffectZombie, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 0.25f);
            }
            else
            {
                FindObjectOfType<AudioManager>().Play("ObjectHit");
                GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 0.25f); 
                /*-------------------- My Code --------------------*/
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

        }
        
    }
/*-------------------- My Code --------------------*/
    IEnumerator ShootAnimation()
    {
        animator.SetBool("Shooting", true);
        yield return new WaitForSeconds(.005f);
        animator.SetBool("Shooting", false);
        yield return new WaitForSeconds(.005f);
        
    }
/*-------------------- My Code --------------------*/
}