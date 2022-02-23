using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb;
    
    [SerializeField] Animator walkAnim;
    [SerializeField] Animator shootAnim;

    [SerializeField] float moveSpeed = 5f;
    float x, y;
    bool isWalking;
    Vector3 moveDir;

    HealthChangeEvent healthChangeEvent = new HealthChangeEvent();

    /*public GameObject arrowPrefab1;*/

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        EventManager.AddInvoker(this);
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        /*if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Attack");
        }*/

        if (x == 0 || y == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
            }
        }

        if (x != 0 || y != 0)
        {
            walkAnim.SetFloat("X", x);
            walkAnim.SetFloat("Y", y);

            if (!isWalking)
            {
                isWalking = true;
                walkAnim.SetBool("IsMoving", isWalking);
            }
        }
        else
        {
            if (isWalking)
            {
                isWalking = false;
                walkAnim.SetBool("IsMoving", isWalking);
                StopMoving();
            }
        }

        moveDir = new Vector3(x, y).normalized;
        Vector3 xxx = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            xxx.x = -20;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            xxx.x = 20;
        }
        transform.localScale = xxx;

    }

    /// <summary>
    /// Makes the player attack
    /// </summary>
    void Attack()
    {
        shootAnim.SetTrigger("Attack");
        //if (Input.GetAxis("Horizontal") < 0)
        //{
        //    GameObject arrow = Instantiate(arrowPrefab1, transform.position, Quaternion.identity);
        //    arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(-1.0f, 0.0f);
        //}
        //if (Input.GetAxis("Horizontal") > 0)
        //{
        //    GameObject arrow = Instantiate(arrowPrefab1, transform.position, Quaternion.identity);
        //    arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(1.0f, 0.0f);
        //}

        //GameObject gameObject = GameObject.Find("arrow");
        //gameObject.transform.position = arrowPoint.position;
        //gameObject.GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    /// <summary>
    /// Stops the player from moving
    /// </summary>
    private void StopMoving()
    {
        rb.velocity = Vector3.zero;
    }

    void FixedUpdate()
    {
        rb.velocity = moveDir * moveSpeed * Time.deltaTime;
    }

    /// <summary>
    /// Add a listener for when the player's health is reduced
    /// </summary>
    /// <param name="listener"></param>
    public void AddHealthChangeEventListener(UnityAction<int> listener)
    {
        healthChangeEvent.AddListener(listener);
    }

    // This method is for testing purpose
    int health = 100;
    int damage = 10;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        health -= damage;
        if(collision.gameObject.tag == "Cut")
        {
            healthChangeEvent.Invoke(health);
        }
    }
}
