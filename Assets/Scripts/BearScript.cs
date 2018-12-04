using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearScript : MonoBehaviour {

    public SoundEffectsHelper soundEffects;
    public SpriteRenderer rippedBear;
    public Animator animator;

    private static int sound = 0;
    private int length;

    private void OnEnable()
    {
        length = soundEffects.GetBearLength();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {

            if (sound < length) {
                soundEffects.MakeBearSound(sound);
                sound++;
            } 

            if (sound == length)
            {
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0;
                rippedBear.sortingOrder = 10;
                animator.SetBool("BearDone", true);
            }

        }
	}


}
