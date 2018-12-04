using UnityEngine;
using System.Collections;

public class CheckInteractionScript : MonoBehaviour
{
    GameObject currBlock = null;
    //public DialogueTrigger dialogue;

    private void Update()
    {
        if (PlayerScript.Active && Input.GetKeyDown(KeyCode.Space))
        {
            bool keep = false;
            if (currBlock != null) {

                //dialogue.TriggerDialogue();
                InteractScript iS = currBlock.GetComponent<InteractScript>();

                if (iS != null) {
                    DialogueTrigger dialogue = currBlock.GetComponent<DialogueTrigger>();
                    if (dialogue != null)
                    {
                        
                        //Time.timeScale = 0;
                        dialogue.TriggerDialogue();
                        //Time.timeScale = 1;
                        //if (Input.GetKeyDown(KeyCode.Return)) // this is never reached
                        //{
                           // FindObjectOfType<DialogueManager>().DisplayNextSentence();
                        //}
                    }
                    keep = iS.Interact();
                }
                if (!keep)
                    currBlock = null;

            }
        }
        /*
        else if (Input.GetKeyDown(KeyCode.G)) {
            InventoryScript stuff = PlayerScript.inventory;
            GameObject drop = stuff.RemoveItem();
            if (drop != null)
            {
                currBlock = drop; //Need to figure out how to actually drop the item onto the floor
            }

        }*/
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        DoorScript ds = coll.gameObject.GetComponent<DoorScript>();
        if (ds == null || !ds.NextRoom()) {
            currBlock = coll.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (currBlock == collision.gameObject)
            currBlock = null;
    }
}
