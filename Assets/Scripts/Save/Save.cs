using System;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class Save
{
    //MISCELLANEOUS
    public string savedScene;
    public int checkpointNum;

    //INVENTORY
    public Sprite[] inventory;
    public int[] nums;
    public int size;

    //ITEMLOAD
    public bool[] active;

    //ENEMY POSITIONS
    public Vector3[] positions;
    public int sizePos;
}