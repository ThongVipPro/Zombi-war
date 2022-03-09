using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;

    [SerializeField]
    int damage;

    float direction;
    Timer destroyTimer;

    private void Awake()
    {
        destroyTimer = gameObject.AddComponent<Timer>();
        destroyTimer.Duration = 3;
        destroyTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (!destroyTimer.Finished)
        {
            float movementSpeed = moveSpeed * Time.deltaTime * direction;
            transform.Translate(movementSpeed, 0, 0);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnermyAI>().UpdateHealth(-damage);
        }
        if (collision.gameObject.tag == "Prison")
        {
            collision.gameObject.GetComponent<Cage>().UpdateHealth(-damage);
        }
        StartCoroutine(Yeeted());
    }

    IEnumerator Yeeted()
    {
        yield return new WaitForEndOfFrame();

        Destroy(gameObject);
    }
}
