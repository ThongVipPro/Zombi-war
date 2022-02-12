using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private float direction;
    private bool hit;
    private Timer destroyTimer;
    private BoxCollider2D boxCollider2D;

    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        destroyTimer = gameObject.AddComponent<Timer>();
        destroyTimer.Duration = 3;
        destroyTimer.Run();
    }


    // Update is called once per frame
    void Update()
    {
        if (!destroyTimer.Finished)
        {
            if (hit) return;
            float movementSpeed = speed * Time.deltaTime * direction;
            transform.Translate(movementSpeed, 0, 0);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxCollider2D.enabled = false;
    }

    public void SetDirection(float _direction)
    {
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider2D.enabled = true;

        float localScalex = transform.localScale.x;
        if (Mathf.Sign(localScalex) != _direction)
            localScalex = -localScalex;

        transform.localScale = new Vector3(localScalex, transform.localScale.y, transform.localScale.z);
    }
    private void Deactive()
    {
        gameObject.SetActive(false);
    }

}
