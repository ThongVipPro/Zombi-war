using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;

public static class EventManager
{
    // Event listener for player getting hit
    static PlayerControl playerHitEventInvoker;
    static UnityAction<int> playerHitEventListener;

    // Event listener for enemy getting hit
    static EnermyAI enemyHitEventInvoker;
    static UnityAction<int> enemyHitEventListener;

    // Event listener for coin pickup
    static PlayerControl coinPickupEventInvoker;
    static UnityAction<int> coinPickupEventListener;

    //Event listener for purchase
    static ShopManager purchaseEventInvoker;
    static UnityAction<int> purchaseEventListener;

    /// <summary>
    /// Adds the invoker for player hit event
    /// </summary>
    /// <param name="script"></param>
    public static void AddPlayerHitEventInvoker(PlayerControl script)
    {
        playerHitEventInvoker = script;
        if (playerHitEventListener != null)
        {
            //playerHitEventInvoker.AddHealthChangeEventListener(playerHitEventListener);
        }
    }

    /// <summary>
    /// Adds the listener for player hit event
    /// </summary>
    /// <param name="handler"></param>
    public static void AddPlayerHitEventListener(UnityAction<int> handler)
    {
        playerHitEventListener = handler;
        if (playerHitEventInvoker != null)
        {
            //playerHitEventInvoker.AddHealthChangeEventListener(playerHitEventListener);
        }
    }

    /// <summary>
    /// Adds the invoker for enemy hit event
    /// </summary>
    /// <param name="script"></param>
    public static void AddEnemyHitEventInvoker(EnermyAI script)
    {
        enemyHitEventInvoker = script;
        if (enemyHitEventListener != null)
        {
            //enemyHitEventInvoker.AddHealthChangeEventListener(enemyHitEventListener);
        }
    }

    /// <summary>
    /// Adds the listener for enemy hit event
    /// </summary>
    /// <param name="handler"></param>
    public static void AddEnemyHitEventListener(UnityAction<int> handler)
    {
        enemyHitEventListener = handler;
        if (enemyHitEventInvoker != null)
        {
            //enemyHitEventInvoker.AddHealthChangeEventListener(enemyHitEventListener);
        }
    }

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
