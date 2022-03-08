using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MerchantControl : MonoBehaviour, NPC
{
    Transform target;
    SpriteRenderer spriteRenderer;

    [SerializeField]
    Dialog dialog;

    public void Interact()
    {
        DialogManager.Instance.ShowDialog(dialog);
    }

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((target.position.x - transform.position.x) < 0)
        {
            spriteRenderer.flipX = true;
        }
        if ((target.position.x - transform.position.x) > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
}
