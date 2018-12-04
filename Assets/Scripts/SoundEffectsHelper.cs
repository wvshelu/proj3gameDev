using UnityEngine;
using System.Collections;

/// <summary>
/// Creating instance of sounds from code with no effort
/// </summary>
public class SoundEffectsHelper : MonoBehaviour
{

    /// <summary>
    /// Singleton
    /// </summary>
    public static SoundEffectsHelper Instance;

    public AudioClip doorCloseSound;
    public AudioClip doorOpenSound;
    public AudioClip footstepSound;
    public AudioClip[] bearSound;
    public AudioClip lightson;
    /*
    public AudioClip bear1;
    public AudioClip bear2;
    public AudioClip bear3;*/

    void Awake()
    {
        // Register the singleton
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of SoundEffectsHelper!");
        }
        Instance = this;
    }

    public void MakeDoorOpenSound()
    {
        MakeSound(doorOpenSound);
    }

    public void MakeDoorCloseSound()
    {
        MakeSound(doorCloseSound);
    }

    public void MakeFootstepSound()
    {
        MakeSound(footstepSound);
    }/*

    public void MakeBear1Sound()
    {
        MakeSound(bear1);
    }

    public void MakeBear2Sound()
    {
        MakeSound(bear2);
    }

    public void MakeBear3Sound()
    {
        MakeSound(bear3);
    }
*/
    public void MakeLightsOnSound()
    {
        MakeSound(lightson);
    }
    
    public void MakeBearSound(int i) {
        MakeSound(bearSound[i]);
    }

    public int GetBearLength() {
        return bearSound.Length;
    }
    /// <summary>
    /// Play a given sound
    /// </summary>
    /// <param name="originalClip"></param>
    private void MakeSound(AudioClip originalClip)
    {
        // As it is not 3D audio clip, position doesn't matter.
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
    }
}

