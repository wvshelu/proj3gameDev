using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SaveSpriteScript : MonoBehaviour {

    public int checkpointNum;
	// Use this for initialization
	void Start () {
        if (SaveScript.SaveGame(SceneManager.GetActiveScene().name, checkpointNum))
            GetComponent<DialogueTrigger>().TriggerDialogue();
	}
}
