using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorCodeScript : MonoBehaviour {

    public Text[] texts;
    public GameObject powerDisplay;
    public Sprite powerOn;
    public DoorScript door;

    private static bool power = false;

    public static void TurnOnPower() {
        power = true;
    }

    private void OnEnable()
    {
        Cursor.visible = true;
        foreach (Text text in texts) {
            text.gameObject.SetActive(power);
        }
        if (power) {
            powerDisplay.GetComponent<SpriteRenderer>().sprite = powerOn;
        }
    }

    public void ChangeText(int text, int change) {
        texts[text].text = "" + (int.Parse(texts[text].text) + change);
        if (int.Parse(texts[0].text) == 5 && int.Parse(texts[1].text) == 2 && int.Parse(texts[2].text) == 4) {
            door.locked = false;
        }
    }

}
