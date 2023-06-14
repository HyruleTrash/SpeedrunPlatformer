﻿using System;
using UnityEngine;
using System.Collections;
[System.Serializable]
public static class AppHelper
{
    #if UNITY_WEBPLAYER
    public static string webplayerQuitURL = "http://google.com";
    #endif
    public static void Quit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER
        Application.OpenURL(webplayerQuitURL);
        #else
        Application.Quit();
        #endif
    }
}
