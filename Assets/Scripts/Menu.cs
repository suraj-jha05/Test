using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button resumeBtn;

    private void Awake()
    {

        
    }
    private void Start()
    {
        resumeBtn.enabled = true;
    }

    public void NewGame()
    {
        //empty the playerprefs
        /*for (int i = 0; i < 9; i++)
        {
            PlayerPrefs.SetString(System.Convert.ToString(i), null);
        }

        PlayerPrefs.SetString("Turn", null);*/

        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

        //loads next scene in the queue
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ResumeGame()
    {
        bool prev = false;
        //1. check if there is a prev game or not
        for (int i = 0; i < 9; i++)
        {
            //PlayerPrefs.GetString(System.Convert.ToString(i)) != null
            if (PlayerPrefs.HasKey(System.Convert.ToString(i)))
            {
                prev = true;
                break;
            }
            
        }

       

        //case 1. -> there is "No" prev game -> make resume btn as disable
        if (prev == false)
        {
            Debug.Log("Resume Button is disabled, since, there is no prev game!");
            resumeBtn.enabled = false;
        }

        //case 2. -> there is a prev game
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void QuitGame()
    {
        Debug.Log("You've Quit the Game!");
        Application.Quit();
    }

    public void Settings()
    {   //loads main menu scene which is one scene before current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
