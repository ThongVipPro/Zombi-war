using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator anim;


    public float x, y;
    private bool isWalking;

    private Vector3 moveDir;


    /*public GameObject arrowPrefab1;*/

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

       /* if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack2();
        }*/
        if (x != 0 || y != 0)
        {
            anim.SetFloat("X", x);
            anim.SetFloat("Y", y);
            
            if (!isWalking)
            {
                isWalking = true;
                anim.SetBool("IsMoving", isWalking);
            }
        }
        else
        {
            if (isWalking)
            {
                isWalking = false;
                anim.SetBool("IsMoving", isWalking);
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
    /*void Attack2()
    {
        anim.SetTrigger("Attack");
        if (Input.GetAxis("Horizontal") < 0)
        {
            GameObject arrow = Instantiate(arrowPrefab1, transform.position, Quaternion.identity);
            arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(-1.0f, 0.0f);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            GameObject arrow = Instantiate(arrowPrefab1, transform.position, Quaternion.identity);
            arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(1.0f, 0.0f);
        }

        *//*GameObject gameObject = GameObject.Find("arrow");
        gameObject.transform.position = arrowPoint.position;
        gameObject.GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));*//*

    }*/
    private void StopMoving()
    {
        rb.velocity = Vector3.zero;
    }
     void FixedUpdate()
    {
        rb.velocity = moveDir * moveSpeed * Time.deltaTime;
    }
}
