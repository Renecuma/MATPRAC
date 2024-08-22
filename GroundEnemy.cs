using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : MonoBehaviour
{
    // Rychlost pohybu nepřítele
    public float speed;

    // Cílová pozice, ke které se nepřítel pohybuje
    Vector3 targetPos;

    // Reference na prázdný objekt obsahující body cesty (waypoints)
    public GameObject ways;

    // Pole bodů cesty
    public Transform[] wayPoints;

    // Index aktuálního bodu cesty
    int pointIndex;

    // Celkový počet bodů cesty
    int pointCount;

    // Směr pohybu (1 pro pohyb dopředu, -1 pro pohyb zpět)
    int direction = 1;

    // Proměnná pro kontrolu, zda je nepřítel otočený doprava
    private bool isFacingRight = true;

    // Reference na komponentu SpriteRenderer pro ovládání vizuálního zobrazení
    private SpriteRenderer spriteRenderer;

    // Metoda, která se volá při probuzení objektu
    private void Awake()
    {
        // Inicializace pole bodů cesty ze dětí prázdného objektu ways
        wayPoints = new Transform[ways.transform.childCount];
        for (int i = 0; i < wayPoints.Length; i++)
        {
            wayPoints[i] = ways.transform.GetChild(i).transform;
        }

        // Inicializace komponenty SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void Start()
    {
        // Nastavení počtu a aktuálního indexu bodů cesty
        pointCount = wayPoints.Length;
        pointIndex = 1;
        targetPos = wayPoints[pointIndex].transform.position;
    }


    private void Update()
    {
        // Nastavení cílové pozice na stejnou výšku jako je výška nepřítele
        targetPos = new Vector3(targetPos.x, transform.position.y, 0);

        // Pohyb k cílové pozici
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);

        // Použití Vector3.Distance pro porovnání pozic
        if (Vector3.Distance(transform.position, targetPos) < 0.01f)
        {
            // Přechod na další bod cesty
            NextPoint();
        }

        // Otočení objektu, pokud se změnil směr pohybu
        if (direction > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (direction < 0 && isFacingRight)
        {
            Flip();
        }
    }

    // Metoda pro přechod na další bod cesty
    void NextPoint()
    {
        // Pokud došel na poslední bod, změň směr na zpět
        if (pointIndex == pointCount - 1)
        {
            direction = -1;
        }
        // Pokud došel na první bod, změň směr na dopředu
        if (pointIndex == 0)
        {
            direction = 1;
        }
        // Přesun na další bod cesty
        pointIndex += direction;
        targetPos = wayPoints[pointIndex].transform.position;
    }

    // Metoda pro otočení objektu
    void Flip()
    {
        // Změna směru, kterým objekt čelí
        isFacingRight = !isFacingRight;

        // Otočení sprite inverzí x měřítka
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
