using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] Animator anim;

    /*public GameObject arrowPrefab1;*/
    /*[SerializeField] private Transform arrowPoint;*/
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack2();
        }

    }
    void Attack2()
    {
        anim.SetTrigger("Attack");
        /*AnimatorStateInfo asi = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
        if (asi.IsName("Player_Attack_Up")) 
        {
            GameObject arrow = Instantiate(arrowPrefab1, transform.position, Quaternion.identity);
            arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(-1.0f, 0.0f);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            GameObject arrow = Instantiate(arrowPrefab1, transform.position, Quaternion.identity);
            arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(1.0f, 0.0f);
        }*/

        /*GameObject gameObject = GameObject.Find("arrow");
        gameObject.transform.position = arrowPoint.position;
        gameObject.GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));*/

    }
}
