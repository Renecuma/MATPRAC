using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // Reference na transformaci pohyblivé platformy
    public Transform platform;

    // Pozice startovního bodu pohybu platformy
    public Transform startPoint;

    // Pozice koncového bodu pohybu platformy
    public Transform endPoint;

    // Rychlost pohybu platformy
    public float speed = 1.5f;

    // Směr pohybu platformy (1 pro pohyb k startovnímu bodu, -1 pro pohyb k koncovému bodu)
    int direction = 1;

    // Metoda, která se volá každý snímek
    private void Update()
    {
        // Získání cílové pozice pro aktuální pohyb platformy
        Vector2 target = currentMovementTarget();

        // Plynulý pohyb platformy k cílové pozici
        platform.position = Vector2.Lerp(platform.position, target, speed * Time.deltaTime);

        // Vzdálenost mezi aktuální pozicí a cílovou pozicí
        float distance = (target - (Vector2)platform.position).magnitude;

        // Pokud je vzdálenost menší než 0.1f, změň směr pohybu platformy
        if (distance <= 0.1f)
        {
            direction *= -1;
        }
    }

    // Metoda pro získání aktuální cílové pozice pro pohyb platformy
    Vector2 currentMovementTarget()
    {
        // Pokud je směr pohybu 1, vrátí pozici startovního bodu, jinak vrátí pozici koncového bodu
        if (direction == 1)
        {
            return startPoint.position;
        }
        else
        {
            return endPoint.position;
        }
    }

    // Metoda pro kreslení pomocných čar v editoru
    private void OnDrawGizmos()
    {
        // Pokud jsou nastaveny reference na platformu a body, nakreslí čáry mezi nimi
        if (platform != null && startPoint != null && endPoint != null)
        {
            Gizmos.DrawLine(platform.position, startPoint.position);
            Gizmos.DrawLine(platform.position, endPoint.position);
        }
    }
}
