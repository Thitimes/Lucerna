using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    GameObject SettingsMenu;

    public void ButtonStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ButtonSettings()
    {
        SettingsMenu.SetActive(true);
    }

    public void SettingsButtonBack()
    {
        SettingsMenu.SetActive(false);
    }

    public void ButtonCredits()
    {
        SceneManager.LoadScene(1);
    }

    public void ButtonExit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
