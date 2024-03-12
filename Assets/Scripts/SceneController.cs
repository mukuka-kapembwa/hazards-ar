using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] RectTransform fader;

    // Controls animation behaviour
    private void Start()
    {
        fader.gameObject.SetActive(true);
        LeanTween.alpha(fader, 1, 0);
        LeanTween.alpha(fader, 0, 0.5f).setOnComplete (() => 
        {
            fader.gameObject.SetActive(false);
        });
    }

    // Switches between the different scenes
    public void SwitchScenes(string sceneName)
    {
        fader.gameObject.SetActive(true);
        LeanTween.alpha(fader, 0, 0);
        LeanTween.alpha(fader, 1, 0.5f).setOnComplete (() =>
        {
            SceneManager.LoadScene(sceneName);
        });
    }
}
