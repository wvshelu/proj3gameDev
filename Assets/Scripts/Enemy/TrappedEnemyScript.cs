using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrappedEnemyScript : MonoBehaviour {

    public int distance = 100;
    public int currDistance;
    public Sprite[] sprites;
    public bool flustered;

    private static Vector2[] directions = { new Vector2(0.1f, 0), new Vector2( 0, 0.1f) , 
        new Vector2(-0.1f, 0) , new Vector2(0, -0.1f) };

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody;
    private int currDirection;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        currDirection = Random.Range(0, 4);
        currDistance = distance;
    }
    // Update is called once per frame
    void Update () {
        if (currDistance > 0) {
            rigidbody.MovePosition(rigidbody.position + directions[currDirection]);
            currDistance--;
        } else {
            currDistance = distance;
            currDirection = flustered ? Random.Range(0, 4) : (currDirection + 1) % sprites.Length;
            spriteRenderer.sprite = sprites[currDirection];
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (flustered) {
            currDirection = Random.Range(0, 4);
            spriteRenderer.sprite = sprites[currDirection];
        }
    }
}
