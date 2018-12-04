using UnityEngine.SceneManagement;
using UnityEngine;

public class NewEnemyScript : MonoBehaviour {

    public Sprite[] sprites;

    public int index;
    public bool prioritizeY;

    private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;
    //private SpriteRenderer spriteRenderer;
    //private GameObject player;
    private float speed;
    private Transform[] targets;
    private int currtarget;
    private int lagtime;
    private Vector2 movementVector;

    private bool collided;
    // Use this for initialization
    void Start () {
        targets = new Transform[3];
        targets[2] = PlayerScript.GetPlayer().transform;
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        speed = 0.1f;
        currtarget = 2;
        lagtime = 100;
        collided = false;
        transform.position = EnemyPosScript.GetPosition(index, transform.position);
    }
	
	// Update is called once per frame
	void Update () {
        if (PlayerScript.Active) {
            if (lagtime == 0)
            {
                lagtime = 100;
                speed += 0.01f;
            }
            lagtime--;
            //Debug.Log("targets[currtarget].position.y: " + targets[currtarget].position.y);
            //Debug.Log("speed: " + speed);
            bool checkY = targets[currtarget].position.y - speed / 2 < transform.position.y &&
                                             transform.position.y < targets[currtarget].position.y + speed / 2;
            bool checkX = targets[currtarget].position.x - speed / 2 < transform.position.x &&
                                             transform.position.x < targets[currtarget].position.x + speed / 2;
            if (checkX && checkY)
            {
                currtarget++;
                return;
            }
            if (!collided) {
                if (checkX)
                    prioritizeY = true;
                else if (checkY)
                    prioritizeY = false;
            }
            collided = false;

            if (prioritizeY)
            {
                if (transform.position.y < targets[currtarget].transform.position.y)
                {
                    movementVector = new Vector2(0, speed);
                    spriteRenderer.sprite = sprites[0];
                }
                else
                {
                    movementVector = new Vector2(0, -speed);
                    spriteRenderer.sprite = sprites[1];
                }

            }
            else
            {
                if (transform.position.x < targets[currtarget].transform.position.x)
                {
                    movementVector = new Vector2(speed, 0);
                    spriteRenderer.sprite = sprites[2];
                }
                else
                {
                    movementVector = new Vector2(-speed, 0);
                    spriteRenderer.sprite = sprites[3];
                }


            }
            rigidbody.MovePosition(rigidbody.position + movementVector);
            EnemyPosScript.UpdatePosition(index, transform.position);
            //print(index + ": " + prioritizeY);
        }


    }

    public void ChangeTarget(int i, Transform target) {
        targets[i] = target;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("collided");
        collided = true;
        if (collision.gameObject.tag.Equals("Player")) {
            print("GAME OVER");
            SceneManager.LoadScene("Death");
            //PlayerScript.Health -= 30;

        } else {
            BlockScript blockScript = collision.gameObject.GetComponent<BlockScript>();
            print(collision.gameObject);
            print(blockScript);
            if (blockScript != null) {
                currtarget = 0;
                int nearest = blockScript.GetNearestEdge(targets[2], transform);
                targets[0] = collision.gameObject.transform.GetChild(nearest / 10);
                targets[1] = collision.gameObject.transform.GetChild(nearest % 10);
                if (targets[0] == targets[1]) {
                    currtarget = 1;
                }

                print(targets[0].parent.gameObject.name);
                print(targets[0].gameObject.name);
                print(targets[1].gameObject.name);
            }
            prioritizeY = !prioritizeY;
            rigidbody.MovePosition(rigidbody.position - movementVector);
        }
        //EnemyPosScript.UpdatePosition(index, transform.position);
    }


}
