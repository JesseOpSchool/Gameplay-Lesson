using System.ComponentModel.Design;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    public float speed = 10;
    public Rigidbody2D rb;
    public float jumpAmount = 35;
    public float gravityScale = 10;
    public float fallingGravityScale = 40;
    bool isGrounded = true;
    private bool canDoubleJump;
    public GameObject Bullet;
    private float facingDirX = 1;
    public int hp = 1;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //get the input of horizontal movement and puts it into float dirX
        float dirX = Input.GetAxisRaw("Horizontal");

        //movement left right
        transform.Translate(transform.right * dirX * speed * Time.deltaTime);

        if (dirX == -1)
        {
            transform.eulerAngles = Vector3.forward * 180;
        }

        if (dirX == 1)
        {
            transform.eulerAngles = Vector3.forward * 0;
        }

        if (dirX == -1 || dirX == 1)
        {
            facingDirX = dirX;
            
        }

        //shooting
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject spawnedBullet = Instantiate(Bullet, transform.position, Quaternion.identity);

            //change fire direction
            spawnedBullet.GetComponent<Bullet>().dirX = facingDirX;

        }

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || canDoubleJump))
        {
            if (!isGrounded)
            {
                canDoubleJump = false;
                rb.velocity = new Vector2(0, 0);
            }
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        }
        if (rb.velocity.y >= 0)
        {
            rb.gravityScale = gravityScale;
        }
        else if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallingGravityScale;
        }

       
    }

    void Die()
    {
        hp--;
        Debug.Log("Player Dies!");
    }

    //ground check
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Ground" || collision.collider.gameObject.tag == "Wall")
        {
            isGrounded = true;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Ground" || collision.collider.gameObject.tag == "Wall")
        {
            isGrounded = false;
            canDoubleJump = true;
        }
        
    }

}
