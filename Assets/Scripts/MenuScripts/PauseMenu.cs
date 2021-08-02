using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject HUD;

    [SerializeField] private bool isPaused;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            isPaused = !isPaused;
        }

        if (isPaused) {
            ActivateMenu();
        } else {
            DeactivateMenu();
        }
    }

    private void ActivateMenu() {
        Time.timeScale = 0;
        AudioListener.pause = true;
        pauseMenuUI.SetActive(true);
        HUD.SetActive(false);
    }

    public void DeactivateMenu() {
        Time.timeScale = 1;
        AudioListener.pause = false;
        pauseMenuUI.SetActive(false);
        HUD.SetActive(true);
        isPaused = false;
    }
}
