using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 15f;
    public float lifetime = 3f;
    public float dirX = 1f;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {

        //movement left right
        transform.Translate(transform.right * dirX * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy"))
        {

            Enemy enemyScript = collision.gameObject.GetComponent<Enemy>();

            enemyScript.takeDamage();
            Destroy(gameObject);
        }
    }
}
