using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused;
    public GameObject pauseMenuUI;

    private void Start()
    {
        Pause();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (gameIsPaused)
            {
                Resume();
            } else if(Input.GetKeyDown(KeyCode.Escape))
            {
                Pause();
            }
        }
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;

        gameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;

        gameIsPaused = true;
    }
}
