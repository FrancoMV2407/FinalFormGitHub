using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipButton : MonoBehaviour
{
    public void TriggerSkip()
    {
        SceneManager.LoadScene("LoadingScreen");
    }
}
