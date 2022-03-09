using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cage : MonoBehaviour
{
    [SerializeField]
    HealthBar healthBar;

    [SerializeField]
    int maxHealth = 100;
    int health = 0;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update() { }

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
            StartCoroutine(Dead());
        }
        healthBar.SetHealth(health);
    }

    private void OnCollisionEnter2D(Collision2D collision) { }

    IEnumerator Dead()
    {
        yield return new WaitForEndOfFrame();
        Destroy(gameObject);
    }
}
