using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Reference na objekt reprezentující pauzovací menu
    public GameObject pauseMenu;

    // Přepínač, zda je hra pozastavena
    public bool isPaused;

    // Metoda, která se volá před prvním snímkem
    void Start()
    {
        // Deaktivace pause menu při startu
        pauseMenu.SetActive(false);
    }

    // Metoda, která se volá každý snímek
    void Update()
    {
        // Pokud hráč stiskne klávesu Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Pokud je hra pozastavena, znovu spustí hru, jinak ji pozastaví
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    // Metoda pro pozastavení hry
    public void PauseGame()
    {
        // Aktivace pause menu, zastavení času
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    // Metoda pro znovuspouštění hry z pozastaveného stavu
    public void ResumeGame()
    {
        // Deaktivace pause menu, obnovení času
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    
    // Metoda pro přechod na hlavní menu
    public void GoToMainMenu()
    {
        // Obnovení času a přechod na scénu s indexem 0 (hlavní menu)
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    // Metoda pro ukončení hry
    public void QuitGame()
    {
        // Ukončení aplikace
        Application.Quit();
    }
}
