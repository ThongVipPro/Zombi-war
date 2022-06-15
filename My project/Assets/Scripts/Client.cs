using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    List<Transform> portals;
    int i = 0;

    Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        portals = new List<Transform>();

        timer = gameObject.AddComponent<Timer>();
        timer.Duration = Random.Range(2, 5);
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        // T?o ra portal d?a trên input
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // L?y v? trí c?a chu?t và fix c?ng tr?c x, z
            var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0;
            mouseWorldPos.x = -8;

            // Kh?i t?o gameObject cho portal
            var bossPortalGameObject = Resources.Load("Prefab/BossPortal") as GameObject;
            if (bossPortalGameObject != null)
            {
                // Spawn portal lên v? trí ??nh tr??c
                var bossPortal = Instantiate(
                    bossPortalGameObject.transform,
                    mouseWorldPos,
                    Quaternion.identity
                );
                // ??t vai trò cho portal
                bossPortal.gameObject.AddComponent<BossFactory>();
                // Thêm portal vào list ?? d? qu?n lý
                portals.Add(bossPortal);
            }
            else
            {
                throw new System.ArgumentException("Prefab does not exist.");
            }
        }

        // T?o ra portal d?a trên input
        if (Input.GetKeyDown(KeyCode.E))
        {
            // L?y v? trí c?a chu?t và fix c?ng tr?c x, z
            var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0;
            mouseWorldPos.x = -8;

            // Kh?i t?o gameObject cho portal
            var creepPortalGameObject = Resources.Load("Prefab/CreepPortal") as GameObject;
            if (creepPortalGameObject != null)
            {
                // Spawn portal lên v? trí ??nh tr??c
                var creepPortal = Instantiate(
                    creepPortalGameObject.transform,
                    mouseWorldPos,
                    Quaternion.identity
                );
                // ??t vai trò cho portal
                creepPortal.gameObject.AddComponent<CreepFactory>();
                // Thêm portal vào list ?? d? qu?n lý
                portals.Add(creepPortal);
            }
            //var fastCreepGameObject = Resources.Load("Prefab/FastCreep") as GameObject;
            //if (fastCreepGameObject != null)
            //{
            //    var fastCreep = Instantiate(
            //        fastCreepGameObject.transform,
            //        new Vector3(0, 0, 0),
            //        Quaternion.identity
            //    );
            //}
            //else
            //{
            //    throw new System.ArgumentException("Prefab does not exist.");
            //}
        }

        if (timer.Finished)
        {
            if (i < portals.Count)
            {
                portals[i].gameObject.GetComponent<EnemyFactory>().portalTransform = portals[i];
                if (Random.Range(0, 2) == 0)
                {
                    portals[i].gameObject.GetComponent<EnemyFactory>().CreateFastEnemy();
                }
                else
                {
                    portals[i].gameObject.GetComponent<EnemyFactory>().CreateSlowEnemy();
                }
                i++;
            }
            else
            {
                i = 0;
            }
            timer.Duration = Random.Range(2, 5);
            timer.Run();
        }
    }
}
