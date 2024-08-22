using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    // Reprezentace dialogu, který se má zobrazit
    public Dialogue dialogue;

    // Reference na textové pole pro jméno postavy v dialogu
    public TMP_Text nameText;

    // Reference na textové pole pro zobrazení dialogového textu
    public TMP_Text dialogueText;

    // Reference na animátor pro ovládání animací dialogu
    public Animator animator;

    // Fronta pro uchovávání vět dialogu
    private Queue<string> sentences;

    // Metoda, která se volá před prvním snímkem
    void Start()
    {
        // Inicializace fronty vět dialogu
        sentences = new Queue<string>();
    }

    // Metoda pro zahájení dialogu s určitým dialogem
    public void StartDialogue(Dialogue dialogue)
    {
        // Spustí animaci otevření dialogu
        animator.SetBool("IsOpen", true);

        // Nastaví jméno postavy v dialogu
        nameText.text = dialogue.name;

        // Vyčistí frontu vět dialogu
        sentences.Clear();

        // Naplní frontu větami z aktuálního dialogu
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        // Zobrazí první větu dialogu
        DisplayNextSentence();
    }

    // Metoda pro spuštění dialogu pomocí zadefinovaného dialogu
    public void TriggerDialogue()
    {
        StartDialogue(dialogue);
    }

    // Metoda pro zobrazení další věty dialogu
    public void DisplayNextSentence()
    {
        // Pokud je fronta prázdná, ukončí dialog
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        // Získá další větu z fronty a spustí animaci psaní věty
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    // Metoda pro postupné zobrazování písmen v dialogové větě
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        float letterDelay = 0.05f;

        // Pro každé písmeno v dialogové větě postupně zobrazí písmeno a počká na další
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(letterDelay);
        }
    }

    // Metoda pro ukončení dialogu a spuštění animace zavření dialogu
    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }
}
