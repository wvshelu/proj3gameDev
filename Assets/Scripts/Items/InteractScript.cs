using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class InteractScript : MonoBehaviour
{
    public bool pickup;
    public bool onOff;
    public int pickupNum;
    public string room;
    public bool keep;
    /*
    public bool bear1;
    public bool bear2;
    public bool bear3;
    public bool bear4;
    public bool bear5;
    //public bool bear6;
    public Animator animator;
    
    public GameObject rippedbear;*/
    public GameObject[] activateItems;

    public bool Interact()
    {
        print("Interact");
        foreach (GameObject a in activateItems)
        {
            ItemScript itemScript = a.GetComponent<ItemScript>();
            if (itemScript != null)
                itemScript.Toggle();
            else
                a.SetActive(!a.activeSelf);
        }

        if (pickup)
        {
            // Move gameObject to inventory Here
            PlayerScript.inventory.AddItem(gameObject, pickupNum);
            // Tell PlayerScript that just picked something up
            ItemScript item = GetComponent<ItemScript>();
            if (item != null)
            {
                item.Toggle();
            }
        }
        /*
        else if (onOff)
        {
            Debug.Log("darkness on/off");
            GameObject.FindGameObjectWithTag("Darkness").SetActive(false);
        }
        /*
        else if (!string.IsNullOrEmpty(room)) //THIS METHOD ISNT USED FOR DOORS ANYMORE, USE DOORSCRIPT
        {
            //StartCoroutine(LoadWithDoorSound());
            //SoundEffectsHelper.Instance.MakeDoorOpenSound();
           // System.Threading.Thread.Sleep(3000);
           // SceneManager.LoadScene(room);
        }
        /*
        else if (bear1)
        {
            SoundEffectsHelper.Instance.MakeBear1Sound();
            bear1 = false;
            bear2 = true;
        }
        else if (bear2)
        {
            //SoundEffectsHelper.Instance.MakeBear2Sound();
            bear2 = false;
            bear3 = true;
        }
        else if (bear3)
        {
            SoundEffectsHelper.Instance.MakeBear2Sound();
            bear3 = false;
            bear4 = true;
            //animator.SetBool("BearDone", true); //set diary key on floor
        }
        else if (bear4)
        {
            bear4 = false;
            bear5 = true;
            //rippedbear = GameObject.Find("rippedbear");
            //if (rippedbear.GetComponent<SpriteRenderer>().sprite = null)
            //{
                //Debug.Log("bear not found");
            //} 
            //activateItems[0].GetComponent<SpriteRenderer>().sprite = rippedbear.GetComponent<SpriteRenderer>().sprite;
        }
        else if (bear5)
        {
            SoundEffectsHelper.Instance.MakeBear3Sound();
            bear5 = false;
            animator.SetBool("BearDone", true); //set diary key on floor
        }


    */
        return keep;
    }
}
