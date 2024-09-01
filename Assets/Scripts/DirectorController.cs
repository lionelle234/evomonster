using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DirectorController : MonoBehaviour
{
    [SerializeField] private Enemy golemBoss;
    [SerializeField] private GameObject pauseScreen, pauseButton, retryScreen, black;
    public static DirectorController instance;
    private Player player;
    private AudioSource audioSource;
    [SerializeField] private AudioClip[] clips;


    private void Awake()
    {
        instance = this;
        player = FindAnyObjectByType<Player>();
        audioSource = GetComponent<AudioSource>();
        Time.timeScale = 1;
    }
    private void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        QualitySettings.vSyncCount = 0;

    }

    public void DeathSound()
    {

        audioSource.clip = clips[0];
        audioSource.Play();
    }


    public void RetryGame()
    {
        


        Time.timeScale = 0;
        player.playerInput.enabled = false;
        pauseButton.SetActive(false);
        black.SetActive(true);
        retryScreen.SetActive(true);


    }

    public void ContinueGame()
    {

        Time.timeScale = 1;

        player.playerInput.enabled = true;
        SceneManager.LoadScene("Test");
    }

    public void RestartScene()
    {
        Time.timeScale = 1;

        player.playerInput.enabled = true;
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        audioSource.clip = clips[1];
        audioSource.Play();
        player.playerInput.SwitchCurrentActionMap("Pause");
        pauseButton.SetActive(false);
        pauseScreen.SetActive(true);

    }

    public void UnPauseGame()
    {

        Time.timeScale = 1;
        audioSource.clip = clips[1];
        audioSource.Play();
        player.playerInput.SwitchCurrentActionMap("Virus");
        pauseButton.SetActive(true);
        pauseScreen.SetActive(false);
    }

    public void WinScene()
    {

        SceneManager.LoadScene("Win");
    }

}
