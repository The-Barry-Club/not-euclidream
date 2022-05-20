using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    float deltatime = 0.0f;

    // Update is called once per frame
    void Update()
    {
        deltatime += (Time.unscaledDeltaTime - deltatime) * 0.1f;
    }


    /// <summary>
    /// OnGUI is called for rendering and handling GUI events.
    /// This function can be called multiple times per frame (one call per event).
    /// </summary>
    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;
        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0,0,w,h*2/100);
        style.alignment = TextAnchor.UpperRight;
        style.fontSize = h*2/100;
        style.normal.textColor = new Color(1f,1f,1f,1.0f);
        float msec = deltatime*1000.0f;
        float fps = 1.0f / deltatime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec,fps);
        
        GUI.Label(rect,text,style);
    }
}
