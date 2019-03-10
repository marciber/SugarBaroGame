using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuButtonManager : MonoBehaviour
{
    public Transform canvas;

    void Update()
    {
        
    }

    public void Pause()
    {
        SceneManager.LoadScene ("PauseMenu");
      
         // stop the time
        Time.timeScale = 0;
    }

    public void NewGameButton(string Scene1)
    {
        SceneManager.LoadScene(Scene1);
    }

    public void AboutMenuButton(string AboutMenu)
    {
        SceneManager.LoadScene(AboutMenu);
    }

    public void OptionsMenuButton(string OptionsMenu)
    {
        SceneManager.LoadScene(OptionsMenu);
    }

    public void MainMenuButton(string MainMenu)
    {
        SceneManager.LoadScene(MainMenu);
    }

    public void PauseMenuButton(string PauseMenu)
    {
        Time.timeScale = 0;
        SceneManager.LoadScene(PauseMenu);
    } 

    

    public void ResumeMenuButton(string PauseMenu)
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;          
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        
    }


    public void RestartMenuButton(string Scene1)
    {
        SceneManager.LoadScene(Scene1);
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }





}
