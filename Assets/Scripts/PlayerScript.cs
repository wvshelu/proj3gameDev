using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour {

    private static GameObject player;
    //private Vector2 speed;
    private static Rigidbody2D playerRigidbody;
    private static SpriteRenderer spriteRenderer;
    private static int currInteract;
    //private static int currSpriteNum;
    private static int delay;
    //public static int Health = 100;
    public static bool Active = true;

    public Sprite[] sprites = new Sprite[4];
    //private static Sprite[][] all_sprites;// = GetAllSprites();

    //inventory stuff
    public static InventoryScript inventory;
    private static bool start = true;

    float xAxis;
    float yAxis;

	// Use this for initialization
	void Awake () {
        inventory = GetComponent<InventoryScript>();
        player = gameObject;
        if (start) {
            currInteract = 0;
            //currSpriteNum = 0;
            delay = 10;
            //all_sprites = GetAllSprites();
            start = false;
        }

	} 

    // Use this for initialization
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        player = gameObject;
        player.transform.Translate(DoorScript.position);
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[currInteract];
        foreach (Transform child in transform)
            child.gameObject.SetActive(false);
        print(currInteract);
        transform.GetChild(currInteract).gameObject.SetActive(true);
        //Health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        xAxis = Input.GetAxisRaw("Horizontal");
        yAxis = Input.GetAxisRaw("Vertical");

        Vector2 movementVector = new Vector2(xAxis/5, yAxis/5);

*/
        if (Active) {

            Vector2 movementVector;
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                toggleInteract(0);
                movementVector = new Vector2(0.2f, 0);
                //Transform right = transform.GetChild(0);//transform.eulerAngles = new Vector3(0, 0, 90);
                //right.gameObject.SetActive(true);

            }
            else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                //transform.eulerAngles = new Vector3(0, 0, -90);
                toggleInteract(1);
                movementVector = new Vector2(-0.2f, 0);
            }
            else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                //transform.eulerAngles = new Vector3(0, 0, 180);
                toggleInteract(2);
                movementVector = new Vector2(0, 0.2f);
            }
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                //transform.eulerAngles = new Vector3(0, 0, 0);
                toggleInteract(3);
                movementVector = new Vector2(0, -0.2f);
            }
            else
            {
                movementVector = new Vector2(0, 0);
            }
            playerRigidbody.MovePosition(playerRigidbody.position + movementVector);
        }

    }
    /*

    private void toggleInteract(int curr) {
        if (currInteract == curr) {
            if (delay > 0) {
                delay--;
            } else {
                currSpriteNum = (currSpriteNum + 1) % all_sprites[curr].Length;
                delay = 5;
            }

        } else {
            transform.GetChild(currInteract).gameObject.SetActive(false);
            currSpriteNum = 0;
            currInteract = curr;
            transform.GetChild(currInteract).gameObject.SetActive(true);
        }
        spriteRenderer.sprite = all_sprites[curr][currSpriteNum]; //sprites[currInteract];
        if (currSpriteNum % 4 == 0) {
            SoundEffectsHelper.Instance.MakeFootstepSound();
        }
    }*/

    private void toggleInteract(int curr)
    {
        if (currInteract == curr)
        {
            spriteRenderer.sprite = sprites[curr]; //all_sprites[curr][currSpriteNum];
        }
        else
        {
            transform.GetChild(currInteract).gameObject.SetActive(false);
            //currSpriteNum = 0;
            currInteract = curr;
            transform.GetChild(currInteract).gameObject.SetActive(true);
        }

        if (delay > 0)
        {
            delay--;
        }
        else
        {
            delay = 10;
            SoundEffectsHelper.Instance.MakeFootstepSound();
        }
        // spriteRenderer.sprite = all_sprites[curr][currSpriteNum]; //sprites[currInteract];
    }

    public static GameObject GetPlayer()
    {
        return player;
    }

    public static void SetPlayer(GameObject p) {
        player = p;
    }

    public static float GetWidth() {
        return spriteRenderer.size.x;
    }

    public static float GetHeight()
    {
        return spriteRenderer.size.y;
    }
    /*

    public static Sprite[][] GetAllSprites() {

        return new Sprite[][]{ Resources.LoadAll<Sprite>("front"), Resources.LoadAll<Sprite>("front"), 
            Resources.LoadAll<Sprite>("front"), Resources.LoadAll<Sprite>("front") };
    }*/

    /*
	// Update is called once per frame
	void Update () {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2( transform.position.x + speed.x * inputX,
                                       transform.position.y + speed.y * inputY);

        if (CheckCollision(movement)) {
            transform.position = movement;
        }


    }

    private bool CheckCollision(Vector2 pos) {
        for (int i = 0; i < wallArray.Length; i++) {
            if (wallArray[i].bounds.Contains(pos)) {
                return false;
            }
        }
        return true;
    }

    */
}
