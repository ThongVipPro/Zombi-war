using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    // L?y ra t�n lo?i qu�i
    public override EnemyType GetEnemyType()
    {
        return EnemyType.Boss;
    }
}
