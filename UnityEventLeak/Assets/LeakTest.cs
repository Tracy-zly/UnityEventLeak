using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LeakTest : MonoBehaviour
{
    WeakReference w;
    GameObject go;
    Button btn;

    void Start()
    {
        go = GameObject.Find("Button");
        btn = go.GetComponent<Button>();
    }

    void Update()
    {
        if (w != null && w.IsAlive)
        {
            Debug.Log("Alive");
            System.GC.Collect();
        }
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(20, 100, 100, 100), "test1"))
        {
            Test t = new Test();
            t.ret = new UnityAction(t.action);
            btn.onClick.AddListener(t.ret);
            w = new WeakReference(t);
            btn.onClick.Invoke();
            Debug.Log("test1");
        }
        if (GUI.Button(new Rect(130, 100, 100, 100), "test2"))
        {
            var t = w.Target as Test;
            
            btn.onClick.RemoveListener(t.ret);
            Debug.Log("test2");
        }
        if (GUI.Button(new Rect(240, 100, 100, 100), "test3"))
        {
            DestroyImmediate(go);
            Debug.Log("test3");
        }
    }
}


