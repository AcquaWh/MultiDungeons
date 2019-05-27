using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Core.ControllerSystem;

public class Pause : MonoBehaviour
{
    public static bool GameIsPaused = false;
    [SerializeField]
    GameObject pauseMenuUI;
    public AudioClip buttonSound;
    private float throwSpeed = 2000f;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

    private void Start()
    {
        pauseMenuUI.SetActive(false);
    }
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (ControllerSystem.Start1)
        {
            if (GameIsPaused)
            {
                float vol = Random.Range(volLowRange, volHighRange);
                source.PlayOneShot(buttonSound, vol);
                Resume();
            } else
            {
                float vol = Random.Range(volLowRange, volHighRange);
                source.PlayOneShot(buttonSound, vol);
                PauseGame();
            }
        }
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
