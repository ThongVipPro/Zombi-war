using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;

public static class EventManager
{
    // Event listener for coin pickup
    static PlayerControl coinPickupEventInvoker;
    static UnityAction<int> coinPickupEventListener;

    // Event listener for people saved
    static PlayerControl peopleSavedEventInvoker;
    static UnityAction<int> peopleSavedEventListener;

    // Event listener for purchase
    static ShopManager purchaseEventInvoker;
    static UnityAction<int> purchaseEventListener;

    /// <summary>
    /// Add the invoker for picking up coin
    /// </summary>
    /// <param name="script"></param>
    public static void AddCoinPickupEventInvoker(PlayerControl script)
    {
        coinPickupEventInvoker = script;
        if (coinPickupEventListener != null)
        {
            coinPickupEventInvoker.AddCoinPickupEventListener(coinPickupEventListener);
        }
    }

    /// <summary>
    /// Add the listener for picking up coin
    /// </summary>
    /// <param name="handler"></param>
    public static void AddCoinPickupEventListener(UnityAction<int> handler)
    {
        coinPickupEventListener = handler;
        if (coinPickupEventInvoker != null)
        {
            coinPickupEventInvoker.AddCoinPickupEventListener(coinPickupEventListener);
        }
    }

    /// <summary>
    /// Add the invoker for people saved
    /// </summary>
    /// <param name="script"></param>
    public static void AddPeopleSavedEventInvoker(PlayerControl script)
    {
        peopleSavedEventInvoker = script;
        if (peopleSavedEventListener != null)
        {
            peopleSavedEventInvoker.AddPeopleSavedEventListener(peopleSavedEventListener);
        }
    }

    /// <summary>
    /// Add the listener for picking up coin
    /// </summary>
    /// <param name="handler"></param>
    public static void AddPeopleSavedEventListener(UnityAction<int> handler)
    {
        peopleSavedEventListener = handler;
        if (peopleSavedEventInvoker != null)
        {
            peopleSavedEventInvoker.AddPeopleSavedEventListener(peopleSavedEventListener);
        }
    }

    /// <summary>
    /// Add the invoker for purchase
    /// </summary>
    /// <param name="script"></param>
    public static void AddPurchaseEventInvoker(ShopManager script)
    {
        purchaseEventInvoker = script;
        if (purchaseEventListener != null)
        {
            purchaseEventInvoker.AddPurchaseEventListener(purchaseEventListener);
        }
    }

    /// <summary>
    /// Add the listener for purchase
    /// </summary>
    /// <param name="handler"></param>
    public static void AddPurchaseEventListener(UnityAction<int> handler)
    {
        purchaseEventListener = handler;
        if (purchaseEventInvoker != null)
        {
            purchaseEventInvoker.AddPurchaseEventListener(purchaseEventListener);
        }
    }
}
