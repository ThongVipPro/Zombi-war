using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnController : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;

    const float SpawnBorderSize = 5f;
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

        for(int i = 0; i < 20; i++)
        {
            Spawner();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawner()
    {
        Vector3 location = new Vector3(Random.Range(minSpawnX, maxSpawnX),
                                       Random.Range(minSpawnY, maxSpawnY),
                                       transform.position.z);

        GameObject enemy = Instantiate(enemyPrefab) as GameObject;
        enemy.transform.position = location;
    }
}
