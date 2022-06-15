using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creep : Enemy
{
    // L?y ra tên lo?i quái
    public override EnemyType GetEnemyType()
    {
        return EnemyType.Creep;
    }
}
