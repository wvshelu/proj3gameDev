using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{

    public SoundEffectsHelper soundEffects;
    //public SpriteRenderer lightswitch_on;

    private void OnEnable()
    {
        soundEffects.MakeLightsOnSound();
    }

    /*
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            soundEffects.MakeLightsOnSound();
            
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0;
            //lightswitch_on.sortingOrder = 10;
               
           

        }
    }*/


}
