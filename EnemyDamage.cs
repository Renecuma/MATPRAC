using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    // Reference na zdraví hráče
    public PlayerHealth playerHealth;

    // Počet bodů zranění, které nepřítel způsobí hráči
    public int damage = 2;


    // Metoda, která se volá jednou za snímek


    // Metoda, která se volá při kolizi s jiným 2D objektem
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Zkontroluje, zda došlo ke kolizi s objektem s tagem "Player"
        if (collision.gameObject.tag == "Player")
        {
            // Zavolá metodu TakeDamage z objektu hráčova zdraví a předá počet bodů zranění
            playerHealth.TakeDamage(damage);
        }
    }
}
