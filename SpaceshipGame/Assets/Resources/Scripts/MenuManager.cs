using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    public GameObject deathMenu;
    public GameObject winMenu;
    public GameObject pauseMenu;
    public PlayerMovement player;
    // Use this for initialization
    void Start () {
        pauseMenu.SetActive(false);
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        Cursor.visible = false;

        // deathMenu = GameObject.Find("DeathMenu");
    }
	
	// Update is called once per frame
	void Update () {
        


            if(Input.GetKeyDown(KeyCode.Escape))
            {
                if (pauseMenu.activeSelf == false && deathMenu.activeSelf == false)
                {
                    pauseMenu.SetActive(true);
                    player.andarBaixo = player.andarCima = player.andarDir = player.andarEsq = false;
                    Cursor.visible = true;
                    Time.timeScale = 0;
                }

                else
                {
                    Resume();
                }
            } 
            
            if(pauseMenu.activeSelf == true)
                {
                    if (Input.GetKeyDown(KeyCode.R))
                    {
                        Restart();
                    }

                    if (Input.GetKeyDown(KeyCode.M))
                    {
                        Menu();
                    }
        }

            if (deathMenu.activeSelf == true || winMenu.activeSelf == true)
            {
                Time.timeScale = 0;
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Application.LoadLevel(Application.loadedLevel);
                    Time.timeScale = 1;
                }

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    //Application.Quit();
                    SceneManager.LoadScene("MainMenu");
                    Time.timeScale = 1;
                }
            }
        }
        
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
        Time.timeScale = 1;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1;
    }
}

