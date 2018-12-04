using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour {

    public int toggleNum;

    private GameObject game;
	// Use this for initialization
	void Awake () {
        game = gameObject;
        game.SetActive(ItemLoadScript.GetItem(toggleNum));
	}

    public void Toggle() {
        ItemLoadScript.ToggleItem(toggleNum);
        game.SetActive(ItemLoadScript.GetItem(toggleNum));
    }
}
