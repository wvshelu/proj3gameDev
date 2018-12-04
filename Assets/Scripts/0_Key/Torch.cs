using UnityEngine;
using UnityEngine.SceneManagement;

public class Torch : MonoBehaviour
{
    /*
    private Vector3 target;
    //private bool move;
    //private float speed;
    public GameObject wielder;
    public Text text;
    public GameObject firstHalf;
    public GameObject secondHalf;


    public Sprite offSprite;
    public Sprite fireSprite;
    //public GameObject point;

    public bool dragging;

    private List<GameObject> collided;*/

    public Sprite offSprite;
    public Sprite fireSprite;

    public GameObject fire;
    public MergeScript merge;

    public GameObject key1, key2;

    private bool dragging;
    private SpriteRenderer spriteRenderer;

    /* private void Awake()
     {
         //collided = new List<GameObject>();
     }*/

    private void Start()
    {
        fire.SetActive(false);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        dragging = false;
        Cursor.visible = true;
        key1.SetActive(InventoryScript.ContainsItem(0));
        key2.SetActive(InventoryScript.ContainsItem(1));
    }

    private void Update()
    {
        if (dragging) {
            Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
            transform.position = Vector3.MoveTowards(transform.position, target, 400);
        }

        /*if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;

            //Collider2D collider = Physics2D.OverlapCircle(target, 0.1f);
            //Debug.Log("collider: " + collider);

            if (collider != null && collider.gameObject.CompareTag(wielder.tag))
            {
                if (wielder.CompareTag(collider.gameObject.tag))
                {
                    Debug.Log("picked up torch");
                    dragging = true;
                }
            }


        }
        if (dragging)
        {
            // changes picture of object
            GetComponent<SpriteRenderer>().sprite = fireSprite;

            // changes position of object
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
            wielder.transform.position = Vector3.MoveTowards(transform.position, target, 400);


            // "wields" together the two halfs of the key

            Vector3 targetTorch = GetComponent<CircleCollider2D>().transform.position;
            targetTorch.z = transform.position.z;

            Collider2D collider2 = Physics2D.OverlapCircle(target, 2);

            if (collider2.CompareTag("Key") || collider2.CompareTag("Key2")) {
                bool flag = false;
                foreach (GameObject c in collided)
                {
                    if (c.CompareTag(collider2.tag)) {
                        flag = true;
                    }
                }
                //if (!flag)
                    //addCollided(collider2.gameObject);

            }
            Debug.Log("collider2: " + collider2);
            /*
            GameObject obj = new GameObject("CombinedKey");
            obj.SetActive(true);
            

            obj.AddComponent<Drag>();
            obj.GetComponent<Drag>().myHalf = obj;
            obj.AddComponent<BoxCollider2D>();
            */
        /*

            Debug.Log(collided.Count);

            if (collided.Count == 2)
            {

                //obj.tag = "Key";
                /*

                firstHalf.transform.parent = obj.transform;
                secondHalf.transform.parent = obj.transform;

                firstHalf.GetComponent<Drag>().myHalf = obj;
                secondHalf.GetComponent<Drag>().myHalf = obj;

                //Collider2D newCollider = obj.GetComponent<BoxCollider2D>() as BoxCollider2D;
                Collider2D a = firstHalf.GetComponent<BoxCollider2D>() as BoxCollider2D;
                Collider2D b = secondHalf.GetComponent<BoxCollider2D>() as BoxCollider2D;

                //Vector3 aV = a.bounds.center;
                //Vector3 bV = b.bounds.center;x

                Vector3 aVSize = a.bounds.size;
                Vector3 bVSize = b.bounds.size;


                //Vector3 cV = new Vector3(aV.x - bV.x, aV.y - bV.y, aV.z);
                Vector3 cVSize = new Vector3(aVSize.x - bVSize.x, aVSize.y - bVSize.y, aVSize.z);
                obj.GetComponent<BoxCollider2D>().bounds.Expand(cVSize);//= new Bounds(cV, cVSize);

                */
               /* firstHalf.transform.parent = secondHalf.transform;
                firstHalf.GetComponent<Drag>().myHalf = secondHalf;
                secondHalf.GetComponent<Collider2D>().bounds.Expand(20);
                text.text = "connected!";*/

                //Debug.Log(firstHalf.GetComponent<Collider2D>().gameObject.tag);
                //Debug.Log(secondHalf.GetComponent<Collider2D>().gameObject.tag);

            //}


        //}

        /*
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("mouse up");
            //move = false;


            //switch back picture of object
            GetComponent<SpriteRenderer>().sprite = offSprite;


            //clear collided array
            collided = new List<GameObject>();

            dragging = false;
        }*/
    }

    private void OnMouseDown()
    {
        dragging = true;
        fire.SetActive(dragging);
        spriteRenderer.sprite = fireSprite;
    }

    private void OnMouseUp()
    {
        dragging = false;
        fire.SetActive(dragging);
        spriteRenderer.sprite = offSprite;
    }

    /*void addCollided(GameObject coll)
    {

        collided.Add(coll.gameObject);

    }*/

}