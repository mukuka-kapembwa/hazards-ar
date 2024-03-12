using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetUserInfo : MonoBehaviour
{
    public TextMeshProUGUI SetUserOptions;

    // Sets UserName from GetUserSettings
    public void Awake()
    {
        SetUserOptions.text = GetUserInfo.GetUserName.UserName;
    }
}
