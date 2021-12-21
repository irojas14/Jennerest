using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingResolution : MonoBehaviour
{
    public void HD()
    {
        Screen.SetResolution(1080, 720, true);
    }

    public void HDi()
    {
        Screen.SetResolution(1280, 720, true);
    }

    public void FullHD()
    {
        Screen.SetResolution(1920, 1080, true);
    }
}
