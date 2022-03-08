using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum GameState
{
    FreeRoam,
    Dialog,
    Shop
}

public class GameController : MonoBehaviour
{
    GameState state;

    [SerializeField]
    PlayerControl playerControl;

    [SerializeField] MerchantControl merchantControl;

    // Start is called before the first frame update
    void Start()
    {
        DialogManager.Instance.OnShowDialog += () =>
        {
            state = GameState.Dialog;
        };
        DialogManager.Instance.OnHideDialog += () =>
        {
            state = GameState.FreeRoam;
        };
        ShopManager.Instance.OnOpenShop += () =>
        {
            state = GameState.Shop;
        };
        ShopManager.Instance.OnCloseShop += () =>
        {
            state = GameState.FreeRoam;
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (state == GameState.FreeRoam)
        {
            playerControl.HandleUpdate();
        }
        else if (state == GameState.Dialog)
        {
            DialogManager.Instance.HandleUpdate();
        }
        else if (state == GameState.Shop)
        {
            ShopManager.Instance.HandleUpdate();
        }
    }
}
