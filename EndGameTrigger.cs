using UnityEngine;

public class EndGameTrigger : MonoBehaviour
{
    // Reference na objekt reprezentující EndGameMenu
    public GameObject endGameMenu;

    // Metoda, která se volá při startu objektu
    private void Start()
    {
        // Zajistí, že EndGameMenu není na začátku aktivované
        if (endGameMenu != null)
        {
            endGameMenu.SetActive(false);
        }
    }

    // Metoda, která se volá při vstupu objektu do triggeru
    private void OnTriggerEnter(Collider other)
    {
        // Zkontroluje, zda vstupující kolider je hráč
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hráč vstoupil do triggeru!");
            // Zobrazí EndGameMenu
            ShowEndGameMenu();
        }
    }

    // Metoda pro zobrazení EndGameMenu
    private void ShowEndGameMenu()
    {
        // Aktivuje EndGameMenu nebo provede jiné akce
        if (endGameMenu != null)
        {
            Debug.Log("Zobrazuji EndGameMenu");
            endGameMenu.SetActive(true);
        }
    }
}
