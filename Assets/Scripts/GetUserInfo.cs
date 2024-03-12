using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GetUserInfo : MonoBehaviour
{
    public static GetUserInfo GetUserName; // Instance or variable of current class
    public TMP_InputField InputField;
    public string UserName;

    // Singleton to ensure that there is only one instance of this gameObject
    private void Awake()
    {
        if(GetUserName == null)
        {
            GetUserName = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetUserName()
        {
            UserName = InputField.text;
        }
}
