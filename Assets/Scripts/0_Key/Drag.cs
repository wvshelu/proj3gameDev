using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class Drag : MonoBehaviour
{
    //private Vector3 target;
    public GameObject myHalf;

    private bool dragging = false;

    //private Collider2D[] colliderArray = new Collider2D[2];



    private void Update()
    {
        /*
        if (Input.GetMouseButtonDown(0)) 
        {

            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;

            Collider2D collider = Physics2D.OverlapCircle(target, 0.1f);
            Debug.Log("collider: " + collider);

            if (collider != null && collider.gameObject.CompareTag(myHalf.tag)) {
                if (myHalf.CompareTag(collider.gameObject.tag))
                {
                    dragging = true;
                }
            }

             
        }*/
        if (dragging) {
            Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
            transform.position = Vector3.MoveTowards(transform.position, target, 400);
        }

        /*
        if (Input.GetMouseButtonUp(0)) 
        {
            Debug.Log("mouse up");
            //move = false;
            dragging = false;
        }*/
    }

    private void OnMouseDown()
    {
        dragging = true;
    }

    private void OnMouseUp()
    {
        dragging = false;
    }





}
