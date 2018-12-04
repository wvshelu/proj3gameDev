using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    private Rigidbody2D rigidbody;
    private float direction;
    private int steps;
    private bool seen;
    private int mask;

    public static float SPEED = 0.1f;

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        direction = transform.eulerAngles.z;
        steps = Random.Range(100, 150);
        mask = 1 << LayerMask.NameToLayer("Wall");
        seen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            Vector2 movementVector;
            if (steps < 0 && !seen)
            {
                direction += 90 * ((int)Random.Range(0, 2) * 2 - 1);
                transform.eulerAngles = new Vector3(0, 0, direction);
                steps = Random.Range(100, 150);
            }
            movementVector = new Vector2(Mathf.Cos(Mathf.Deg2Rad * direction) * SPEED, Mathf.Sin(Mathf.Deg2Rad * direction) * SPEED);
            steps--;

            rigidbody.MovePosition(rigidbody.position + movementVector);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("changing");
        if (seen) {
            Vector3 difference = PlayerScript.GetPlayer().transform.position - transform.position;
            if ((int)direction % 180 == 90)
            {
                direction = difference.x > 0 ? 0 : 180;
            }
            else
            {
                direction = difference.y > 0 ? 90 : 270;
            }
        } else {
            direction += 90 * ((int)Random.Range(0, 2) * 2 - 1);
            transform.eulerAngles = new Vector3(0, 0, direction);
            steps = Random.Range(100, 150);
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            float x = PlayerScript.GetWidth(), y = PlayerScript.GetHeight();
            if (!Physics2D.Linecast(transform.position, collision.transform.position + new Vector3(x / 2, 0, 0), mask)
                || !Physics2D.Linecast(transform.position, collision.transform.position + new Vector3(x / (-2), 0, 0), mask)
               || !Physics2D.Linecast(transform.position, collision.transform.position + new Vector3(0, y / 2, 0), mask)
                || !Physics2D.Linecast(transform.position, collision.transform.position + new Vector3(0, y / (-2), 0), mask))
            {
                print("seen");
                Vector3 difference = collision.transform.position - transform.position;
                if (Mathf.Abs(difference.x) > Mathf.Abs(difference.y))
                {
                    direction = difference.x > 0 ? 0 : 180;
                }
                else
                {
                    direction = difference.y > 0 ? 90 : 270;
                }
                transform.eulerAngles = new Vector3(0, 0, direction);
                steps = 1;
                seen = true;
            }
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            seen = false;
        }

    }

}
