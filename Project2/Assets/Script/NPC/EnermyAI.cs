using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;

public class EnermyAI : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    float checkRadius;

    [SerializeField]
    float attackRadius;

    [SerializeField]
    bool shouldRotate;

    [SerializeField]
    LayerMask whatIsPlayer;

    SpriteRenderer spriteRenderer;
    Transform target;
    Rigidbody2D rb;
    Animator anim;
    Vector2 movement;
    Vector3 dir;

    private bool isInChaseRange;
    private bool isInAttackRange;

    [SerializeField]
    HealthBar healthBar;

    [SerializeField]
    GameObject CoinPrefab;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        anim.SetBool("isRunning", isInChaseRange);
        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);
        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer);

        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        movement = dir;
        if (shouldRotate)
        {
            anim.SetFloat("X", dir.x);
            anim.SetFloat("Y", dir.y);
        }

        // Don't flip the scale of the object, it's gonna mess up the UI, use "SpriteRenderer.Flip" instead.
        //Vector3 xxx = transform.localScale;
        if ((target.position.x - transform.position.x) < 0)
        {
            spriteRenderer.flipX = true;
        }
        if ((target.position.x - transform.position.x) > 0)
        {
            spriteRenderer.flipX = false;
        }
        if (isInAttackRange)
        {
            anim.SetBool("isRunning", false);
        }
    }

    private void FixedUpdate()
    {
        if (isInChaseRange && !isInAttackRange)
        {
            MoveCharacter(movement);
        }
        if (isInAttackRange)
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void MoveCharacter(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));
    }

    // This method is for testing purpose
    int health = 100;
    int damage = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            health -= damage;
            healthBar.SetHealth(health);
        }
        if (health <= 0)
        {
            anim.SetBool("isDead", true);
            StartCoroutine(Dead());
        }
    }

    IEnumerator Dead()
    {
        yield return new WaitForSeconds(0.5f);
        // Instantiate a new coin prefab.
        GameObject obj = Instantiate(CoinPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
