using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnPlayButton ()
    {
        SceneManager.LoadScene(LevelData.instance.currLevel);
    }
    public void OnQuitButton ()
    {
        Application.Quit();
    }
    
    public void OnMenuButton ()
    {
        SceneManager.LoadScene(0);
    }
    public void OnLevel1 ()
    {
        SceneManager.LoadScene(2);
    }
    public void OnLevel2 ()
    {
        SceneManager.LoadScene(3);
    }
    public void OnLevel3 ()
    {
        SceneManager.LoadScene(4);
    }
        public void OnLevel4 ()
    {
        SceneManager.LoadScene(5);
    }
    public void OnBackButton ()
    {
        SceneManager.LoadScene(0);
    }
     public void OnLevelSelect ()
    {
        SceneManager.LoadScene(1);
    }
    public void OnTutorial ()
    {
        SceneManager.LoadScene(6);
    }
}
