using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpRoomPlayer : MonoBehaviour {
    public GameObject b1;
    public GameObject b2;

    public Text timerText;
    public float timeRemaining;
    public bool dying;


	// Use this for initialization
	void Start () {
        //base.Start();
        Physics2D.IgnoreCollision(b1.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(b2.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
	
	// Update is called once per frame
	void Update () {
        if (dying)
        {
            timerText.GetComponent<Text>().enabled = true;
            timeRemaining -= Time.deltaTime ;
            if (timeRemaining > 0)
            {
                timerText.text = "TIME UNTIL DEATH: " + (int) timeRemaining + "! GO SHOWER!!!";
            }
            else
            {
                timerText.text = "TIME'S UP!";
                SceneManager.LoadScene("Death");

            }
        }
        else 
        {
            timerText.GetComponent<Text>().enabled = false;
            timeRemaining = 6;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("BH"))
        {
            dying = true;
        }
        else if (collision.gameObject.CompareTag("SH"))
        {
            dying = false;
        }
    }



}
