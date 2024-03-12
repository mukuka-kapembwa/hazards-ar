using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource SoundPlayer;

    public void DisableSoundAlerts()
    {
        GetUserSettings.GetUserOptions.IsSound = false;
    }

    public void EnableSoundAlerts()
    {
        GetUserSettings.GetUserOptions.IsSound = true;
    }

    public void PlaySound()
    {
        if(GetUserSettings.GetUserOptions.IsSound == true)
        {
            SoundPlayer.Play();
        }
    }
}
