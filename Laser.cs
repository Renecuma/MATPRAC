using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour
{
    // Minimální doba (v sekundách) mezi zjevením a zmizením laseru
    public int minInterval = 2;

    // Maximální doba (v sekundách) mezi zjevením a zmizením laseru
    public int maxInterval = 4;

    // Reference na objekt reprezentující laser
    private GameObject myObject;

    // Přepínač pro aktivaci/deaktivaci laseru
    bool active = true;

    // Proměnná indikující, zda právě probíhá rutina
    bool running = false;

    // Metoda, která se volá každý snímek
    void Update()
    {
        // Získání referenčního objektu (laseru) ze dětí tohoto objektu
        myObject = transform.GetChild(0).gameObject;

        // Pokud není právě spuštěna rutina, spusť ji
        if (!running)
        {
            StartCoroutine(AppearDisappearRoutine());
        }
    }

    // Rutina pro zjevení a zmizení laseru s náhodným intervalem
    IEnumerator AppearDisappearRoutine()
    {
        // Indikátor, že rutina právě běží
        running = true;

        // Čekání na náhodný interval mezi minInterval a maxInterval
        yield return new WaitForSeconds(Random.Range(minInterval, maxInterval));

        // Pokud je myObject (laser) neprázdný
        if (myObject != null)
        {
            // Nastaví aktivitu laseru na hodnotu proměnné 'active'
            myObject.SetActive(active);

            // Přepne hodnotu proměnné 'active' na opačnou
            active = !active;
        }

        // Indikátor, že rutina skončila
        running = false;
    }
}
