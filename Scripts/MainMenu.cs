using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Code cretaed using this tutorial: https://www.youtube.com/watch?v=zc8ac_qUXQY&ab_channel=Brackeys

public class MainMenu : MonoBehaviour
{
    /*-------------------- My Code --------------------*/
    public void PlayMap1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex  + 1);
    }

    public void PlayMap2()
    {
        SceneManager.LoadScene(3);
    }
    /*-------------------- My Code --------------------*/
    
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
