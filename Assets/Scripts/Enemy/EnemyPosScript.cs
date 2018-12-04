using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPosScript : MonoBehaviour {

    private static Vector3[] positions;
    private static int size;

    public static Vector3 GetPosition(int i, Vector3 pos) {
        if (i < size)
            return positions[i];
        size++;
        positions[i] = pos;
        return pos;
    }

    public static void UpdatePosition(int i, Vector3 pos) {
        positions[i] = pos;
    }

    public static void LoadDefault() {
        positions = new Vector3[4];
        size = 0;
    }

    public static void PopulateSave(Save save)
    {
        save.positions = new Vector3[positions.Length];
        for (int i = 0; i < positions.Length; i++)
        {
            save.positions[i] = positions[i];
        }
        save.sizePos = size;
    }

    public static void ReadFromSave(Save save)
    {
        positions = new Vector3[save.positions.Length];
        for (int i = 0; i < positions.Length; i++)
        {
            positions[i] = save.positions[i];
        }
        size = save.sizePos;
    }

}
