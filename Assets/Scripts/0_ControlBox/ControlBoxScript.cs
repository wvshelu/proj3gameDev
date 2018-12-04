using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlBoxScript : MonoBehaviour {

    public GameObject placeHolder;
    public NewEnemyScript enemyScript;
	// Use this for initialization
	void Start () {
        Cursor.visible = true;
	}

    private void OnEnable()
    {
        placeHolder.transform.position = PlayerScript.GetPlayer().transform.position;
        PlayerScript.GetPlayer().transform.Translate(new Vector3(100, 100));
        placeHolder.SetActive(true);
        enemyScript.ChangeTarget(2, placeHolder.transform);
    }

    private void OnDisable()
    {
        PlayerScript.GetPlayer().transform.position = placeHolder.transform.position;
        placeHolder.SetActive(false);
        enemyScript.ChangeTarget(2, PlayerScript.GetPlayer().transform);
    }
}
