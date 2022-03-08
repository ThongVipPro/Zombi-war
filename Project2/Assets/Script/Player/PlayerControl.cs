using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    LayerMask npc;

    SpriteRenderer spriteRenderer;
    Animator anim;

    public int moveSpeed = 100;
    float x,
        y;
    bool isWalking;
    Vector3 moveDir;

    [SerializeField]
    HealthBar healthBar;

    //HealthChangeEvent healthChangeEvent = new HealthChangeEvent();
    CoinPickupEvent coinPickupEvent = new CoinPickupEvent();
    PeopleSavedEvent peopleSavedEvent = new PeopleSavedEvent();

    /*public GameObject arrowPrefab1;*/

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        EventManager.AddCoinPickupEventInvoker(this);
        EventManager.AddPeopleSavedEventInvoker(this);
        DialogManager.Instance.OnHideDialog += () =>
        {
            ShopManager.Instance.OpenShop();
        };
    }

    // Change this method's name so that it will be called in GameController.Update() instead.
    public void HandleUpdate()
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

        // Don't flip the scale of the object, it's gonna mess up the UI, use "SpriteRenderer.Flip" instead.
        // Vector3 player = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            spriteRenderer.flipX = true;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            spriteRenderer.flipX = false;
        }
        //transform.localScale = player;


        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }

        if (health <= 0)
        {
            anim.SetBool("isDead", true);
            StartCoroutine(Dead());
        }
    }

    void Interact()
    {
        var isInteractable = Physics2D.OverlapCircle(transform.position, 1.5f, npc);

        if (isInteractable != null)
        {
            StopMoving();
            isInteractable.GetComponent<NPC>()?.Interact();
        }
    }

    /// <summary>
    /// Makes the player attack
    /// </summary>
    void Attack()
    {
        anim.SetTrigger("Attack");
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
    /// Add listener for picking up coin
    /// </summary>
    /// <param name="listener"></param>
    public void AddCoinPickupEventListener(UnityAction<int> listener)
    {
        coinPickupEvent.AddListener(listener);
    }

    /// <summary>
    /// Add listener for people saved
    /// </summary>
    /// <param name="listener"></param>
    public void AddPeopleSavedEventListener(UnityAction<int> listener)
    {
        peopleSavedEvent.AddListener(listener);
    }

    // This method is for testing purpose
    public int health = 100;
    int damage = 10;

    int money = 0;
    int people = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "People")
        {
            people++;
            Destroy(collision.gameObject);
            peopleSavedEvent.Invoke(people);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Money")
        {
            money += 30;
            Destroy(collision.gameObject);
            coinPickupEvent.Invoke(money);
        }
    }

    IEnumerator Dead()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Time.timeScale = 1f;
    }
}
