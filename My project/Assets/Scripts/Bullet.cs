using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb2d;
    float speed = 1000;

    Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 15;
        timer.Run();

        rb2d.AddForce(transform.up * speed);
    }

    private void FixedUpdate()
    {
        if (timer.Finished)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Enemy>().health--;
        if (collision.gameObject.GetComponent<Enemy>().health == 0)
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
