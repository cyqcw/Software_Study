using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

//  实现按钮退出挂在button上

public class Exit : MonoBehaviour
{
    public void buttonQuit(){
        # if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying=false;
        # else
        Application.Quit();
        # endif
    }
}

