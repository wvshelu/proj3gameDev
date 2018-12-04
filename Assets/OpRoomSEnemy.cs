using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class OpRoomSEnemy: MonoBehaviour
{

    private bool aboutToDie = false;
    private float timeBuffer = 0.5f;
    public GameObject nextE;
    // Update is called once per frame
    void Update()
    {
        if (aboutToDie) 
        {
            timeBuffer -= Time.deltaTime;
            if (timeBuffer < 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("BH"))
        {
            aboutToDie = true;

            nextEnemy(nextE);
        }
    }

    public void nextEnemy(GameObject nextEnemy)
    {
        /* unactive enemies are e1, e2, e3 
            given the current enemy that just died, set the next one active */


        Debug.Log("hey");
        //string nextE = "";
        nextEnemy.SetActive(true);
        StartCoroutine(Coroutine());

    }

    IEnumerator Coroutine()
    {

        yield return new WaitForSeconds(2.5f);

        nextEnemy(nextE);
    }


}
