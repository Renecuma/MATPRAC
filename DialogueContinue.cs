using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueContinue : MonoBehaviour
{
    // Start is called before the first frame update
    public void ContinueButton()
    {
        GameObject.Find("Player").GetComponent<PlayerController>().NPC.GetComponent<DialogueManager>().DisplayNextSentence();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
