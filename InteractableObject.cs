using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InteractableObject : MonoBehaviour
{
    // Start is called before the first frame update
    public void Interact ()
    {
        LevelData.instance.currLevel++;

        SceneManager.LoadScene(LevelData.instance.currLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}