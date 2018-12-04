using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wire : MonoBehaviour {
    private static int numMatched = 0;

    //private GameObject lastClicked;
    private Vector3 target;
    public Sprite uSprite;
    public Sprite sSprite;
    public GameObject hideForNow;

    private bool clicked;

    // Use this for initialization
    void Start () {
        Cursor.visible = true;
    }

    private void OnMouseDown()
    {
        if (LastClickedManager.lastClicked == null)
        {
            Debug.Log("first click: " + gameObject.tag);

            LastClickedManager.lastClicked = gameObject;
            LastClickedManager.lastClicked.GetComponent<SpriteRenderer>().sprite = LastClickedManager.lastClicked.GetComponent<Wire>().sSprite;

        }
        else if (LastClickedManager.lastClicked != null && LastClickedManager.lastClicked == gameObject)
        {
            Debug.Log("same object: " + gameObject.tag);
            LastClickedManager.lastClicked.GetComponent<SpriteRenderer>().sprite = LastClickedManager.lastClicked.GetComponent<Wire>().uSprite;
            LastClickedManager.lastClicked = null;

        }
        else if (LastClickedManager.lastClicked != null && LastClickedManager.lastClicked.CompareTag(gameObject.tag)) 
        {
            Debug.Log("matching: " + gameObject.tag);
            GetComponent<SpriteRenderer>().sprite = GetComponent<Wire>().sSprite;
            if (!hideForNow.activeSelf) {
                IncrementMatched();
            }
            hideForNow.SetActive(true);
            LastClickedManager.lastClicked = null;

        }
        else if (LastClickedManager.lastClicked != null && !LastClickedManager.lastClicked.CompareTag(gameObject.tag))
        {
            Debug.Log("not matching: " + gameObject.tag);
            LastClickedManager.lastClicked.GetComponent<SpriteRenderer>().sprite = LastClickedManager.lastClicked.GetComponent<Wire>().uSprite;
            LastClickedManager.lastClicked = null;
            //LastClickedManager.lastClicked.GetComponent<SpriteRenderer>().sprite = LastClickedManager.lastClicked.GetComponent<Wire>().sSprite;
            //PlayerScript.Health -= 20;
            LastClickedManager.DecrementTries();//.tries -= 1;
        }

    }

    static void IncrementMatched() {
        numMatched++;
        if (numMatched == 5) {
            DoorCodeScript.TurnOnPower();
            LastClickedManager.Finish();
        }//All wires matched 


    }

}
