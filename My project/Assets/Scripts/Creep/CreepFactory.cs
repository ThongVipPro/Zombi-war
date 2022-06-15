using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepFactory : EnemyFactory
{
    public override void CreateFastEnemy()
    {
        var portalTransformposition = portalTransform.transform.position;
        var fastCreepGameObject = Resources.Load("Prefab/FastCreep") as GameObject;
        if (fastCreepGameObject != null)
        {
            var fastCreep = Instantiate(
                fastCreepGameObject.transform,
                new Vector3(
                    portalTransformposition.x,
                    portalTransformposition.y,
                    portalTransformposition.z
                ),
                Quaternion.identity
            );
        }
        else
        {
            throw new System.ArgumentException("Prefab does not exist.");
        }
    }

    public override void CreateSlowEnemy()
    {
        var portalTransformposition = portalTransform.transform.position;
        var slowCreepGameObject = Resources.Load("Prefab/SlowCreep") as GameObject;
        if (slowCreepGameObject != null)
        {
            var slowCreep = Instantiate(
                slowCreepGameObject.transform,
                new Vector3(
                    portalTransformposition.x,
                    portalTransformposition.y,
                    portalTransformposition.z
                ),
                Quaternion.identity
            );
        }
        else
        {
            throw new System.ArgumentException("Prefab does not exist.");
        }
    }
}
