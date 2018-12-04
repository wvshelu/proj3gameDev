using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZenMonster : MonoBehaviour {
    public static readonly int LAST_KEY_NUM = 10;
    public Dialogue dialogue;
    public GameObject lastKey;
    private void OnEnable()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void Update()
    {
        if (PlayerScript.Active) {
            PlayerScript.inventory.AddItem(lastKey, LAST_KEY_NUM);
            gameObject.SetActive(false);
        }
    }
}
