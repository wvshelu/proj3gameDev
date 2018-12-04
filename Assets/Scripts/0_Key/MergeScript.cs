using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MergeScript : MonoBehaviour {
    private bool fire, key, complete;
    public Text text;
    public GameObject firstHalf;
    public GameObject secondHalf;
    public Sprite fullKeySprite;

    void Start()
    {
        fire = false;
        key = false;
        complete = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("KeyHalf1"))
            key = true;
        else if (collision.gameObject.name.Equals("Fire"))
            fire = true;

        if (fire && key && !complete) {
            firstHalf.transform.parent = secondHalf.transform;
            firstHalf.GetComponent<Drag>().myHalf = secondHalf;
            secondHalf.GetComponent<Collider2D>().bounds.Expand(20);
            text.text = "Connected! Press 'space' to exit.";
            InventoryScript.RemoveItemStatic(0);
            InventoryScript.RemoveItemStatic(1);
            InventoryScript.AddItemStatic(fullKeySprite, 2);
            complete = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("KeyHalf1"))
            key = false;
        else if (collision.gameObject.name.Equals("Fire"))
            fire = false;
    }
}
