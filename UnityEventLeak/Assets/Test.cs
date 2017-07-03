using UnityEngine;
using UnityEngine.Events;

public class Test
{
    public UnityAction ret;
    public void action()
    {
        Debug.Log("action");
    }

    ~Test()
    {
        Debug.Log("~Test");
    }
}
