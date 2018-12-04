using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemLoadScript {

    private static bool[] active = {true, true, true, true, true, true, false, false, false};
    private static int change = 6;
    /*
	// Use this for initialization
	void Start () {
        print(active[0] + " " + active[1]);
        for (int i = 0; i < active.Length; i++) {
            transform.GetChild(i).transform.gameObject.SetActive(active[i]);
        }
	}*/

    public static void ToggleItem(int i) {
        active[i] = !active[i];
    }

    public static bool GetItem(int i) {
        return active[i];
    }

    public static void LoadDefault() {
        for (int i = 0; i < change; i++) {
            active[i] = true;
        }
        for (int i = change; i < active.Length; i++)
        {
            active[i] = false;
        }
    }

    public static void PopulateSave(Save save) {
        save.active = new bool[active.Length];
        for (int i = 0; i < active.Length; i++) {
            save.active[i] = active[i];
        }
    }

    public static void ReadFromSave(Save save) {
        active = new bool[save.active.Length];
        for (int i = 0; i < active.Length; i++)
        {
            active[i] = save.active[i];
        }
    }
}
