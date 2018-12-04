using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LastClickedManager : MonoBehaviour {
    public static GameObject lastClicked;
    public Text countText;
    
    private static int tries;
    private static string text;
    // Use this for initialization
    void Start () {
        tries = 3;
        text = "Remaining Tries: " + tries;
    }

    void Update()
    {
        countText.text = text;
    }

    public static void DecrementTries () {
        tries -= 1;
        if (tries < 0)
        {
            SceneManager.LoadScene("Death");
        } else {
            text = "Remaining Tries: " + tries;
        }
    }

    public static void Finish() {
        text = "You heard a click in the distance";
    }
}
