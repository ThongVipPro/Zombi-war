using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum GameState
{
    FreeRoam,
    Dialog
}

public class GameController : MonoBehaviour
{
    GameState state;

    [SerializeField]
    PlayerControl playerControl;

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
    }
}
