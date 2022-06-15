using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyFactory : MonoBehaviour
{
    public Transform portalTransform;

    public abstract void CreateSlowEnemy();

    public abstract void CreateFastEnemy();
}
