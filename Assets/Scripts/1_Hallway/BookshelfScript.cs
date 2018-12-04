using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BookshelfScript : MonoBehaviour {

    private static bool[] selectedBooks; //POSSIBLY SAVE THIS???
                                         // Use this for initialization

    private void Awake()
    {
        selectedBooks = new bool[14];
    }

    public static void ToggleSelected(int num, bool selected) {
        selectedBooks[num] = selected;
        for (int i = 0; i < 3; i++) {
            if (!selectedBooks[i])
                return;
        }
        for (int i = 3; i < selectedBooks.Length; i++)
        {
            if (selectedBooks[i])
                return;
        }
        DoorScript.position = new Vector2(0, 0);
        SceneManager.LoadScene("OperationRoom");
    }
}
