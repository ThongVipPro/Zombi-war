using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creep : Enemy
{
    // L?y ra t�n lo?i qu�i
    public override EnemyType GetEnemyType()
    {
        return EnemyType.Creep;
    }
}
