using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Made with help from a tutorial
//https://www.youtube.com/watch?v=9dYDBomQpBQ&ab_channel=BMo

public class PauseMenu : MonoBehaviour
{
    public GameObject playerCamera;
    public GameObject pauseMenu;
    public bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        Cursor.lockState = CursorLockMode.None;
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    /*-------------------- My Code --------------------*/
    //I created this my self using what I learned when making the volume slider
    public void SetSensitivity(float changedSensitivity)
    {
        playerCamera = GameObject.Find("Main Camera");
        FirstPersonLook camera = playerCamera.GetComponent<FirstPersonLook>();
        camera.sensitivity = changedSensitivity;
        Debug.Log(changedSensitivity);
    }
    /*-------------------- My Code --------------------*/
}
