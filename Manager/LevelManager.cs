using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Character playableCharacter;
    [SerializeField] private Transform spawnPosition;

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject levelComplete;

    public bool levelIsCompleted;

    private void Update()
    {
        /* if (Input.GetKeyDown(KeyCode.P))
         {
             ReviveCharacter();
         }*/

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

        if (playableCharacter.GetComponent<Health>().CurrentHealth <= 0)
        {
            gameOver.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Restart();
            }
        }

        if (levelIsCompleted)
        {
            levelComplete.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    private void ReviveCharacter()
    {
        if(playableCharacter.GetComponent<Health>().CurrentHealth <= 0)
        {
            playableCharacter.GetComponent<Health>().Revive();
            playableCharacter.transform.position = spawnPosition.position;
        }
    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        pauseMenu.SetActive(true);
    }
}
