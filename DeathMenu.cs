using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public GameObject GameOver;  // Reference na obrazovku Game Over

    void Start()
    {
        GameOver.SetActive(false);  // Počáteční deaktivace obrazovky Game Over
    }

    void Update()
    {
        // Žádná specifická logika v Update v tomto případě
    }

    // Metoda pro restartování hry
    public void RestartButton()
    {
        SceneManager.LoadScene(LevelData.instance.currLevel);
    }

    // Metoda pro přechod na hlavní menu
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    // Metoda pro ukončení hry
    public void QuitGame()
    {
        Application.Quit();
    }

    // Metoda pro zobrazení/skrytí obrazovky Game Over
    public void ToggleGameOver(bool show)
    {
        GameOver.SetActive(show);
    }
}
