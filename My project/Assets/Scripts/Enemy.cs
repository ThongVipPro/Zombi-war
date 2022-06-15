using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected float moveSpeed = 0f;
    public int health = 0;

    public enum EnemyType
    {
        Boss,
        Creep
    }

    public abstract EnemyType GetEnemyType();

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * moveSpeed * Time.deltaTime;
    }
}
