using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnController : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPrefab;
    int i = 0;

    Timer timer;

    const float SpawnBorderSize = 4f;
    float minSpawnX;
    float maxSpawnX;
    float minSpawnY;
    float maxSpawnY;

    // Start is called before the first frame update
    void Start()
    {
        minSpawnX = transform.position.x - SpawnBorderSize;
        maxSpawnX = transform.position.x + SpawnBorderSize;
        minSpawnY = transform.position.y - SpawnBorderSize;
        maxSpawnY = transform.position.y + SpawnBorderSize;

        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 0.01f;
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Finished)
        {
            if (i < 20)
            {
                Spawner();
                i++;
                timer.Duration = 0.01f;
                timer.Run();
            }
        }
    }

    void Spawner()
    {
        Vector3 location = new Vector3(
            Random.Range(minSpawnX, maxSpawnX),
            Random.Range(minSpawnY, maxSpawnY),
            transform.position.z
        );

        GameObject enemy = Instantiate(enemyPrefab) as GameObject;
        enemy.transform.position = location;
    }
}
