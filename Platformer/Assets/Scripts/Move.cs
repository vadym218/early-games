using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{
    public int moveSpeed;
    private int jumpHeight;
    private int secondjh;
    private int walljh = 10;
    public bool Die;

    public GameObject Particle;
    public GameObject LastWall;
    public GameObject BlockWall;
    public Transform groundPoint;
    public float radius;
    public LayerMask groundMask;
    public LayerMask wallMask;
    public LayerMask dieMask;
    public float timer;
    public bool secondndjump = false;

    bool isGrounded;
    bool OnWall;
    Rigidbody2D rb2D;
    ParticleSystem par;


    void Start()
    {
        timer = 3;
        rb2D = GetComponent<Rigidbody2D>();
        par = Particle.GetComponent<ParticleSystem>();
    }


    void Update()
    {
        if(isGrounded == true)
        {
            BlockWall = null;
            secondndjump = true;
        }
        if(OnWall == true)
        {
            if (LastWall == BlockWall)
            {
            }
            else
            {
                secondndjump = true;
            }
        }
        if (timer < 0)
        {
            par.startColor = new Color32(0, 86, 255, 255);
            timer = 5;
        }
        timer -= Time.deltaTime;
        Vector2 moveDir = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rb2D.velocity.y);
        rb2D.velocity = moveDir;
        isGrounded = Physics2D.OverlapCircle(groundPoint.position, radius, groundMask);
        OnWall = Physics2D.OverlapCircle(groundPoint.position, radius, wallMask);
        Die = Physics2D.OverlapCircle(groundPoint.position, radius, dieMask);


        if (Input.GetKeyDown(KeyCode.Space) && OnWall == true|| Input.GetKeyDown(KeyCode.UpArrow) && OnWall == true || Input.GetKeyDown(KeyCode.W) && OnWall == true)
        {
            if (LastWall == BlockWall){}
            else
            {
                par.startColor = new Color32(156, 0, 106, 255);
                rb2D.AddForce(transform.up * walljh, ForceMode2D.Impulse);
                BlockWall = LastWall;
            }

        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded==true|| Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true|| Input.GetKeyDown(KeyCode.W) && isGrounded == true)
        {
            par.startColor = new Color32(156, 0, 106, 255);
            rb2D.AddForce(transform.up * jumpHeight,ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.Space) &&  secondndjump == true && isGrounded == false || Input.GetKeyDown(KeyCode.UpArrow) &&  secondndjump == true && isGrounded == false || Input.GetKeyDown(KeyCode.W)  && secondndjump == true && isGrounded == false)
        {
            par.startColor = new Color32(156, 0, 106, 255);
            rb2D.AddForce(transform.up * secondjh, ForceMode2D.Impulse);
            secondndjump = false;
        }
        if (Input.GetKey(KeyCode.DownArrow)|| Input.GetKey(KeyCode.S))
        {
            par.startSize = 7;
            jumpHeight = 15;
            secondjh = 10;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            par.startSize = 3;
            jumpHeight = 30;
            secondjh = 20;
            transform.localScale = new Vector3(2, 2, 2);
        }
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.layer == 9)
        {
            LastWall = hit.gameObject;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundPoint.position, radius);
    }
}

