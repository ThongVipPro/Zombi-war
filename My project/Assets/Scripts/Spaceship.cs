using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefab;

    float speed = 10f;
    Vector2 movement;

    [SerializeField]
    Rigidbody2D rb2d;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = Instantiate(
                bulletPrefab.transform,
                transform.position,
                Quaternion.Euler(0, 0, 90)
            );
        }
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + movement * speed * Time.fixedDeltaTime);
    }
}
