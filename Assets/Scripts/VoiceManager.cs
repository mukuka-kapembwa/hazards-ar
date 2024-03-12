using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceManager : MonoBehaviour
{
    public AudioSource VoicePlayer;

    public void DisableVoiceAlerts()
    {
        GetUserSettings.GetUserOptions.IsVoice = false;
    }

    public void EnableVoiceAlerts()
    {
        GetUserSettings.GetUserOptions.IsVoice = true;
    }

    public void PlayVoice()
    {
        if(GetUserSettings.GetUserOptions.IsVoice == true)
        {
            VoicePlayer.Play();
        }
    }
}
