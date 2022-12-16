using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{
    public float speed = 15f;
    public float dirX = 1f;
    public float startingDir = 1f;
    public ScoreScript scoreScript;
    public int scoreValue;

    Animator anim;

    public int health = 2;
    bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        dirX = startingDir;
        anim = GetComponentInChildren<Animator>();
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
                if (hit.collider.CompareTag("Wall") || hit.collider.CompareTag("Enemy"))
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
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        scoreScript.UpdateScore(scoreValue);
        Destroy(gameObject, 1.4f);
    }
}
