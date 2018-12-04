using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour {

    public string room;
    public Vector2 pos;
    public bool locked;
    public int keyNum;

    public static Vector2 position = new Vector2(0, 0);

    public bool NextRoom() {
        //Scene sceneToLoad = SceneManager.GetSceneByName(room);
        //print(sceneToLoad);
        if (!locked || InventoryScript.ContainsItem(keyNum)) {
            StartCoroutine(LoadWithDoorSound());
            //SceneManager.LoadScene(room);
            position = pos;
            //SoundEffectsHelper.Instance.MakeDoorCloseSound();
            return true;
        }
        return false;
        //SceneManager.MoveGameObjectToScene(PlayerScript.GetPlayer(), sceneToLoad);
    }

    IEnumerator LoadWithDoorSound()
    {
        GameObject.Find("Player").GetComponent<PlayerScript>().enabled = false;
        SoundEffectsHelper.Instance.MakeDoorOpenSound();
        //GameObject.Find("Player").SetActive(false);
        Debug.Log("door sound made");
        yield return new WaitForSeconds(SoundEffectsHelper.Instance.doorOpenSound.length / 4);
        GameObject.Find("Player").SetActive(false);
        SoundEffectsHelper.Instance.MakeDoorCloseSound();
        yield return new WaitForSeconds(SoundEffectsHelper.Instance.doorCloseSound.length / 4);
        SceneManager.LoadScene(room);
    }
}
