using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;

public class DialogManager : MonoBehaviour
{
    [SerializeField]
    GameObject dialogBox;

    [SerializeField]
    Text dialogText;

    [SerializeField]
    int animSpeed;

    Dialog dialog;
    bool isTyping;

    public event Action OnShowDialog;
    public event Action OnHideDialog;

    public static DialogManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void ShowDialog(Dialog dialog)
    {
        OnShowDialog?.Invoke();
        this.dialog = dialog;
        dialogBox.SetActive(true);
        StartCoroutine(DialogAnim(dialog.Lines[0]));
    }

    public IEnumerator DialogAnim(string line)
    {
        isTyping = true;
        dialogText.text = "";
        foreach (var letter in line.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / animSpeed);
        }
        isTyping = false;
    }

    int currentLine = 0;

    // Change this method's name so that it will be called in GameController.Update() instead.
    public void HandleUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isTyping)
        {
            currentLine++;
            if (currentLine < dialog.Lines.Count)
            {
                StartCoroutine(DialogAnim(dialog.Lines[currentLine]));
            }
            else
            {
                OnHideDialog?.Invoke();
                currentLine = 0;
                dialogBox?.SetActive(false);
            }
        }
    }
}
