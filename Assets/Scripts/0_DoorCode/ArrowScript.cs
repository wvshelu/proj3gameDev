using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour {

    public int change;
    public int text;
    public DoorCodeScript codeScript;
    private void OnMouseDown()
    {
        codeScript.ChangeText(text, change);
    }

}
