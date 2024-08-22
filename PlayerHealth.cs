using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private Animator animator;
    public GameObject GameOver;  // Reference to the GameOver screen

    void Start()
    {
        animator = GetComponent<Animator>();
        //GameOver.SetActive(false);  // Initially deactivate the GameOver screen
    }

    void Update()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        animator.SetTrigger("HurtTrigger");


        if (health <= 0)
        {
            ShowGameOver();
        }
    }
    
    public void Heal(int amount)
    {
        health += amount;
        // Add any additional logic for healing if needed
    }

    void ShowGameOver()
    {
        // Activate the GameOver screen
        GameOver.SetActive(true);
    }
}
