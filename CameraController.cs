using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Offset pro umístění kamery za cílovým objektem
    private Vector3 offset = new Vector3(0f, 0f, -30f);

    // Čas, který zabere plynulý přechod kamery na nové umístění
    private float smoothTime = 0.25f;

    // Proměnná pro plynulý pohyb kamery
    private Vector3 velocity = Vector3.zero;

    // Cílový objekt, ke kterému se bude kamera přizpůsobovat
    [SerializeField] private Transform target;
    
    void Update()
    {
        // Získání pozice, ke které se bude kamera přibližovat
        Vector3 targetPosition = target.position + offset;

        // Plynulé přesunutí kamery na novou pozici
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
