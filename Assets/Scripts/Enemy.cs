using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 15f;
    public float dirX = 1f;

    Animator anim;

    public int health = 2;
    bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (isAlive)
        {
             transform.Translate(transform.right * dirX * speed * Time.deltaTime);

            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right * dirX, 1f);

            Debug.DrawRay(transform.position, transform.right * 1f * dirX, Color.blue);

            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Wall"))
                {
                    dirX *= -1f;
                }
            }
        }
    }
    public void takeDamage()
    {
        health--;

        if (health <= 0)
        {
            die();
        }
    }

    void die()
    {
        isAlive = false;
        anim.SetBool("isAlive", isAlive);
    }
}
