using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastBoss : Boss
{
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 2f;
        health = 2;
    }
}
