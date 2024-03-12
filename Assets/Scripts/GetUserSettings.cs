using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetUserSettings : MonoBehaviour
{
    public static GetUserSettings GetUserOptions;  // Instance or variable of current class
    public bool IsSound = true;
    public bool IsVoice = true;
    public bool IsVibrationHaptic = true;

    // Singleton to ensure that there is only one instance of this gameObject
    private void Awake()
    {
        if(GetUserOptions == null)
        {
            GetUserOptions = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }    
}
