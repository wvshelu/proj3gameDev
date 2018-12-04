using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour {

    public GameObject slotsEmpty;
    public Sprite defaultImage;
    private Image[] slots;

    private static Sprite[] inventory = new Sprite[6];
    private static int[] nums = new int[6];
    private static int size = 0;
    //public bool[] isFull;

    private void Awake()
    {
        slots = new Image[6];
        int i = 0;
        foreach (Transform child in slotsEmpty.transform) {
            slots[i] = child.GetComponent<Image>();
            i++;
        }


    }

    private void OnEnable()
    {
        RefreshSlots();
    }

    public void AddItem(GameObject item, int pickupNum)
    {
        //invetory full
        if (size == 6)
        {
            Debug.Log("Inventory Full");
        }

        inventory[size] = item.GetComponent<SpriteRenderer>().sprite;
        nums[size] = pickupNum;
        size++;
        RefreshSlots();
        //bool itemAdded = false;
        //find first slot
        /*
        for (int i =0; i < inventory.Length; i++)
        {
            if (isFull[i] == false)
            {
                inventory[i] = item;
                isFull[i] = true;
                //GameObject tempObject = GameObject.Find("Canvas");
                //GameObject newItem = Instantiate(item, new Vector3(0,0,0), Quaternion.identity) as GameObject; //add to UI
                //newItem.transform.SetParent(GameObject.FindGameObjectWithTag("Slot " + (i+1)).transform, false);
                //newItem.transform.localScale += new Vector3(10, 15, 0);
                Sprite itemSprite = item.GetComponent<SpriteRenderer>().sprite;
                GameObject slot = GameObject.Find("item " + (i + 1));
                Debug.Log("slot is set to " + slot); //checking for null 
                slot.GetComponent<Image>().sprite = itemSprite;
                Debug.Log(item.name + " was added");
                itemAdded = true;
                break;
            }
        }*/


    }

    public static void AddItemStatic(Sprite item, int pickupNum) {
        if (size == 6)
        {
            Debug.Log("Inventory Full");
        }

        inventory[size] = item;
        nums[size] = pickupNum;
        size++;
    }

    public static void RemoveItemStatic(int pickupNum) {
        int select = -1;
        for (int i = 0; i < size; i++)
        {
            if (nums[i] == pickupNum) {
                select = i;
                break;
            }

        }
        if (select > -1) {
            for (int j = select + 1; j < size; j++)
            {
                nums[j - 1] = nums[j];
                inventory[j - 1] = inventory[j];
            }
            size--;
        }
        
    }

    private void RefreshSlots() {
        for (int i = 0; i < size; i++) {
            slots[i].sprite = inventory[i];
        }
        for (int i = size; i < 6; i++) {
            slots[i].sprite = defaultImage;
        }
    }

    public GameObject RemoveItem()
    {
        /*
        if (inventory.Length != 0)
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                if(inventory[i] != null)
                {
                    GameObject drop = inventory[i];
                    inventory[i] = null;
                    isFull[i] = false;
                    GameObject slot = GameObject.Find("item " + (i + 1));
                    GameObject panel = GameObject.Find("Slot " + (i + 1));
                    Debug.Log("slot is set to " + slot);
                    Debug.Log("panel is set to" + panel);
                    slot.GetComponent<Image>().sprite = panel.GetComponent<Image>().sprite;
                    Debug.Log(drop.name + " was dropped");
                    drop = null;
                    
                    return drop;
                }
            }
            //Debug.Log(item.name + " is not in inventory");
            
        }
        Debug.Log("Inventory is empty");*/
        return null;
    }

    public static bool ContainsItem(int pickupNum) {
        for (int i = 0; i < size; i++) {
            if (nums[i] == pickupNum)
                return true;
        }
        return false;
    }

    public static void LoadDefault() {
        inventory = new Sprite[6];
        nums = new int[6];
    }

    public static void PopulateSave(Save save) {
        save.inventory = new Sprite[6];
        for (int i = 0; i < size; i++) {
            save.inventory[i] = inventory[i];
        }
        save.nums = new int[6];
        for (int i = 0; i < size; i++)
        {
            save.nums[i] = nums[i];
        }
        save.size = size;
    }

    public static void ReadFromSave(Save save) {
        inventory = new Sprite[6];
        size = save.size;
        for (int i = 0; i < size; i++)
        {
            inventory[i] = save.inventory[i];
        }
        nums = new int[6];
        for (int i = 0; i < size; i++)
        {
            nums[i] = save.nums[i];
        }

    }
}
