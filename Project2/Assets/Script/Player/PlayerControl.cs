using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    int maxHealth = 100;
    public int health = 0;
    public int moveSpeed = 100;
    Collider2D isInteractable;

    Rigidbody2D rb;
    float x,
        y,
        phoneX,
        phoneY;
    public bool isWalking;
    Vector3 moveDir;

    [SerializeField]
    Transform minimapIndicator;

    [SerializeField]
    LayerMask npc;

    SpriteRenderer spriteRenderer;
    Animator anim;

    [SerializeField]
    HealthBar healthBar;

    [SerializeField]
    Dialog dialog;

    [SerializeField]
    Dialog dialog2;

    [SerializeField]
    GameObject poi;

    //HealthChangeEvent healthChangeEvent = new HealthChangeEvent();
    CoinPickupEvent coinPickupEvent = new CoinPickupEvent();
    PeopleSavedEvent peopleSavedEvent = new PeopleSavedEvent();

    /*public GameObject arrowPrefab1;*/

    // Start is called before the first frame update
    void Start()
    {
        DialogManager.Instance.ShowDialog(dialog2);
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        EventManager.AddCoinPickupEventInvoker(this);
        EventManager.AddPeopleSavedEventInvoker(this);
        DialogManager.Instance.OnHideDialog += () =>
        {
            if (isInteractable != null)
            {
                ShopManager.Instance.OpenShop();
            }
        };

        phoneX = phoneY = 0;
    }

    // Change this method's name so that it will be called in GameController.Update() instead.
    public void HandleUpdate()
    {
        isInteractable = Physics2D.OverlapCircle(transform.position, 1.5f, npc);

        //// Controls for pc.
        //x = Input.GetAxisRaw("Horizontal");
        //y = Input.GetAxisRaw("Vertical");
        ///*if (Input.GetMouseButtonDown(0))
        //{
        //    anim.SetTrigger("Attack");
        //}*/

        //if (x == 0 || y == 0)
        //{
        //    if (Input.GetKeyDown(KeyCode.Space))
        //    {
        //        Attack();
        //        AudioManager.Play(AudioFileName.PlayerAttack);
        //    }
        //}

        //if (x != 0 || y != 0)
        //{
        //    anim.SetFloat("X", x);
        //    anim.SetFloat("Y", y);

        //    if (!isWalking)
        //    {
        //        isWalking = true;
        //        anim.SetBool("IsMoving", isWalking);
        //    }
        //}
        //else
        //{
        //    if (isWalking)
        //    {
        //        isWalking = false;
        //        anim.SetBool("IsMoving", isWalking);
        //        StopMoving();
        //    }
        //}

        //moveDir = new Vector3(x, y).normalized;
        //// Don't flip the scale of the object, it's gonna mess up the UI, use "SpriteRenderer.Flip" instead.
        //// Vector3 player = transform.localScale;
        //if (Input.GetAxis("Horizontal") < 0)
        //{
        //    spriteRenderer.flipX = true;
        //    if (moveDir.y == 0)
        //    {
        //        minimapIndicator.eulerAngles = new Vector3(0, 0, -90);
        //    }
        //}
        //if (Input.GetAxis("Horizontal") > 0)
        //{
        //    spriteRenderer.flipX = false;
        //    if (moveDir.y == 0)
        //    {
        //        minimapIndicator.eulerAngles = new Vector3(0, 0, 90);
        //    }
        //}
        //if (Input.GetAxis("Vertical") < 0)
        //{
        //    minimapIndicator.eulerAngles = new Vector3(0, 0, 0);
        //}
        //if (Input.GetAxis("Vertical") > 0)
        //{
        //    minimapIndicator.eulerAngles = new Vector3(0, 0, 180);
        //}
        ////transform.localScale = player;

        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    Interact();
        //}

        //Controls for phone.
        if (phoneX != 0 || phoneY != 0)
        {
            anim.SetFloat("X", phoneX);
            anim.SetFloat("Y", phoneY);

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

        moveDir = new Vector3(phoneX, phoneY).normalized;

        if (phoneX < 0)
        {
            spriteRenderer.flipX = true;
            if (moveDir.y == 0)
            {
                minimapIndicator.eulerAngles = new Vector3(0, 0, -90);
            }
        }
        if (phoneX > 0)
        {
            spriteRenderer.flipX = false;
            if (moveDir.y == 0)
            {
                minimapIndicator.eulerAngles = new Vector3(0, 0, 90);
            }
        }
        if (phoneY < 0)
        {
            minimapIndicator.eulerAngles = new Vector3(0, 0, 0);
        }
        if (phoneY > 0)
        {
            minimapIndicator.eulerAngles = new Vector3(0, 0, 180);
        }

        if (isInteractable != null)
        {
            poi.SetActive(true);
        }
    }

    public void ButtonUpTop()
    {
        phoneY -= 1;
    }

    public void ButtonDownTop()
    {
        phoneY += 1;
    }

    public void ButtonUpBottom()
    {
        phoneY += 1;
    }

    public void ButtonDownBottom()
    {
        phoneY -= 1;
    }

    public void ButtonUpLeft()
    {
        phoneX += 1;
    }

    public void ButtonDownLeft()
    {
        phoneX -= 1;
    }

    public void ButtonUpRight()
    {
        phoneX -= 1;
    }

    public void ButtonDownRight()
    {
        phoneX += 1;
    }

    // FixedUpdate is called every frame at the physic engine fps (50)
    void FixedUpdate()
    {
        rb.velocity = moveDir * moveSpeed * Time.deltaTime;
    }

    /// <summary>
    /// This is used to interact with npc (merchant in this case)
    /// </summary>
    public void Interact()
    {
        if (isInteractable != null)
        {
            isInteractable.GetComponent<NPC>()?.Interact();
        }
    }

    /// <summary>
    /// Makes the player attack
    /// </summary>
    public void Attack()
    {
        //anim.SetFloat("X", phoneX);
        //anim.SetFloat("Y", phoneY);
        anim.SetTrigger("Attack");
        AudioManager.Play(AudioFileName.PlayerAttack);
    }

    /// <summary>
    /// Stops the player from moving
    /// </summary>
    public void StopMoving()
    {
        rb.velocity = Vector3.zero;
    }

    /// <summary>
    /// Update health amount on change
    /// </summary>
    /// <param name="change"></param>
    public void UpdateHealth(int change)
    {
        health += change;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health <= 0)
        {
            health = 0;
            anim.SetBool("isDead", true);
            StartCoroutine(Dead());
        }
        healthBar.SetHealth(health);
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

    int money = 0;
    int people = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "People")
        {
            people++;
            if (people == 3)
            {
                DialogManager.Instance.ShowDialog(dialog);
            }
            Destroy(collision.gameObject);
            peopleSavedEvent.Invoke(people);
        }

        if (collision.gameObject.tag == "Gate")
        {
            if (people == 3)
            {
                Destroy(collision.gameObject);
            }
            else
            {

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Money")
        {
            money += Random.Range(1, 5);
            AudioManager.Play(AudioFileName.Coin);
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
