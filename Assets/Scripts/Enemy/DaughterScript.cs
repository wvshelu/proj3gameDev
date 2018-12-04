using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DaughterScript : MonoBehaviour {

    public Dialogue dialogue;
    //private bool spokenTo;
    public SpriteRenderer daughterlocking;
    

    private void OnEnable()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
    private void Update()
    {
        if (PlayerScript.Active)
        {
            SceneManager.LoadScene("EndGame");
            //daughterlocking.sortingOrder = 10;
        }
    }

}
