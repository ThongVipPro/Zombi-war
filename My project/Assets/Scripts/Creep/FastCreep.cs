using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastCreep : Creep
{
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 4f;
        health = 1;
    }
}
