using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;
using System.Text;
using UnityEditor;

public class EventTool : MonoBehaviour
{
    private static EventTool instance;

    public static EventTool Instance
    {
        get
        {
            if (instance != null)
            {
                EditorGUIUtility.PingObject(root.gameObject);
            }
            return instance;
        }
    }

    StringBuilder methordSb = new StringBuilder();
    string ClassName;
    static Transform root;

    [SerializeField]
    public GUIStyle NewGUIStyle = new GUIStyle();

    private void Awake()
    {
        instance = this;
        NewGUIStyle.normal.background = null;    //设置背景填充  
        NewGUIStyle.normal.textColor = new Color(240,41,78);
        NewGUIStyle.fontSize = 25;       //字体大小  
    }

    private void Start()
    {
        root = this.transform; ;
    }
    // Update is called once per frame
    void Update()
    {
        if (UICamera.hoveredObject != null)
        {
            if (Input.GetMouseButtonDown(1))
            {
                EditorGUIUtility.PingObject(UICamera.hoveredObject);

                UIEventListener uiEventListener = UICamera.hoveredObject.GetComponent<UIEventListener>();
                if (uiEventListener != null)
                {
                    methordSb.Length = 0;
                    methordSb.Append(string.Format("the obj name is{0} \n \n", uiEventListener.gameObject.name));

                    if (uiEventListener.onClick != null)
                    {
                        ClassName = uiEventListener.onClick.Target.ToString();
                        methordSb.Append(string.Format("event type is : {0} methord name is{1} \n \n", "onClick ", uiEventListener.onClick.Method));
                    }

                    if (uiEventListener.onHover != null)
                    {
                        if (string.IsNullOrEmpty(ClassName))
                        {
                            ClassName = uiEventListener.onHover.Target.ToString();
                        }
                        methordSb.Append(string.Format("event type is : {0} methord name is{1}\n \n", "onHover ", uiEventListener.onHover.Method));
                    }

                    if (!string.IsNullOrEmpty(ClassName))
                    {
                        methordSb.Append(string.Format("the script which the events in is{0}", ClassName));
                    }
                    /*   Type type = uiEventListener.GetType();
                       FieldInfo[] fieldInfos = type.GetFields();

                       for (int i = 0; i < fieldInfos.Length; i++)
                       {
                           if (fieldInfos[i].FieldType.BaseType == typeof(MulticastDelegate) && fieldInfos[i].GetValue(uiEventListener) != null)
                           {
                               methordSb.Append(string.Format("the  event type is : {0} methord name is{1}", fieldInfos[i].FieldType, fieldInfos[i].GetValue(uiEventListener)));
                               Debug.LogErrorFormat("base type is{0}  is MulticastDelegate {1} value is {2}", fieldInfos[i].FieldType.BaseType, fieldInfos[i].FieldType.BaseType == typeof(MulticastDelegate), fieldInfos[i].GetValue(uiEventListener).GetType());

                           }

                       }*/
                }
                else
                {
                    Clear();
                }
            }
        }
        else
        {
            Clear();
        }
    }


    private void Clear()
    {
        methordSb.Length = 0;
    }
    private void OnGUI()
    {
        GUILayout.BeginVertical();
        GUILayout.Box(methordSb.ToString(), NewGUIStyle);
        GUILayout.EndVertical();

    }
}
