using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowBoss : Boss
{
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 1f;
        health = 2;
    }
}
