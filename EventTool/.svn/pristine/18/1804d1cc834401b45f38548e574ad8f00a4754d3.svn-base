using Bomber.SGTTools;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DebugMenuToolEditor : MonoBehaviour
{

    [MenuItem("Assets/Add eventTool  %e")]
    private static void AddEventToolToMenu()
    {
        if (EventTool.Instance == null)
        {
            GameObject go = new GameObject();
            go.name = "EventTool";
            GameObject.DontDestroyOnLoad(go);
            go.AddComponent<EventTool>();
        }
    }

    /// <summary>
    /// "ctrl d 快捷键添加"
    /// </summary>
    [MenuItem("Assets/ Add SGTGameDebug  %d")]
    private static void AddDebugToolConsole()
    {
        GameObject go = new GameObject();
        go.name = "DebugTool";
        GameObject.DontDestroyOnLoad(go);
        go.AddComponent<SGTGameDebug>();
    }

}
