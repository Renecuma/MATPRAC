using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    // Reference na komponentu Animator pro ovládání animací postavy
    private Animator anim;

    void Start()
    {
        // Inicializace animátoru při spuštění scény
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Ovládání animace běhu na základě stisknutých kláves
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            // Nastavení parametru "isRunning" na true, pokud jsou stisknuté klávesy pro pohyb
            anim.SetBool("isRunning", true);
        }
        else
        {
            // Nastavení parametru "isRunning" na false, pokud nejsou stisknuté klávesy pro pohyb
            anim.SetBool("isRunning", false);
        }

        // Ovládání animace skoku na základě stisknutých kláves
        if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            // Spuštění animace skoku pomocí triggeru "jump"
            anim.SetTrigger("jump");
        }
    }
}
