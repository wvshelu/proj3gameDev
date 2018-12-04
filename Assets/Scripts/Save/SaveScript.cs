using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveScript : MonoBehaviour {
    // public static readonly string gameDataPath = "/gamesave.json";
    private static Save officialState;

    public static void ReturnToStart() {
        SceneManager.LoadScene("Menu");
    }

    public static void StartGame() {
        InventoryScript.LoadDefault();
        ItemLoadScript.LoadDefault();
        EnemyPosScript.LoadDefault();
        SceneManager.LoadScene("Closet");
        officialState = CreateSaveGameObject();
        officialState.savedScene = "Closet";
        officialState.checkpointNum = -1;
    }

    public static bool SaveGame(string savedScene, int checkpointNum) {
        //string filePath = Application.persistentDataPath + gameDataPath;
        //print(filePath);
        if (officialState.checkpointNum >= checkpointNum) 
            return false;
        officialState = CreateSaveGameObject();
        officialState.savedScene = savedScene;
        officialState.checkpointNum = checkpointNum;

        //string json = JsonUtility.ToJson(save);
        //File.WriteAllText(filePath, json);
        return true;

    }

    public static void LoadSave() {
        //print("loading");
        // string filePath = Application.persistentDataPath + gameDataPath;
        /*
        if (File.Exists(filePath)) {
            print("found game");
            //Save save = JsonUtility.FromJson<Save>(File.ReadAllText(filePath));
            InventoryScript.ReadFromSave(save);
            ItemLoadScript.ReadFromSave(save);
            EnemyPosScript.ReadFromSave(save);
            SceneManager.LoadScene(save.savedScene);
        }
        else {
            StartGame();
        }*/
        if (officialState == null)
            StartGame();
        else {
            InventoryScript.ReadFromSave(officialState);
            ItemLoadScript.ReadFromSave(officialState);
            EnemyPosScript.ReadFromSave(officialState);
            SceneManager.LoadScene(officialState.savedScene);
        }
    }

    public static Save CreateSaveGameObject() {
        Save save = new Save();
        InventoryScript.PopulateSave(save);
        ItemLoadScript.PopulateSave(save);
        EnemyPosScript.PopulateSave(save);
        return save;
    }

    private void OnMouseDown()
    {
        LoadSave();
    }

}
