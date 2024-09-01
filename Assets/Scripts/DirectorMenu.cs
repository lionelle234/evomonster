using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DirectorMenu : MonoBehaviour
{
    [SerializeField] private GameObject infoScreen, info1, info2, mainMenu, backButton, infoButton, nextButton, previousButton;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        Time.timeScale = 1;
    }


    public void StartGame()
    {
        audioSource.Play();
        SceneManager.LoadScene("Test");
    }

    public void ExitGame()
    {

        audioSource.Play();
        Application.Quit();
    }

    public void InfoGame()
    {

        audioSource.Play();
        infoScreen.SetActive(true);
        mainMenu.SetActive(false);
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(backButton);
    }

    public void BackMenu()
    {

        audioSource.Play();
        infoScreen.SetActive(false);
        mainMenu.SetActive(true);
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(infoButton);
    }

    public void NextInfo()
    {

        audioSource.Play();
        info1.SetActive(false);
        info2.SetActive(true);
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(previousButton);
    }

    public void PreviousInfo()
    {
        audioSource.Play(); 
        info1.SetActive(true);
        info2.SetActive(false);
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(nextButton);
    }
}
