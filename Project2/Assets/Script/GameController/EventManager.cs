using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    static PlayerControl invoker;
    static UnityAction<int> listener;

    /// <summary>
    /// Adds the invoker
    /// </summary>
    /// <param name="script"></param>
    public static void AddInvoker(PlayerControl script)
    {
        invoker = script;
        if(listener != null)
        {
            invoker.AddHealthChangeEventListener(listener);
        }
    }

    public static void AddListener(UnityAction<int> handler)
    {
        listener = handler;
        if(invoker != null)
        {
            invoker.AddHealthChangeEventListener(listener);
        }
    }
}
