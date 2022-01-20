using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class character : MonoBehaviour {

    [Header("Actions")]
    public float GravitationGunRadius;
    public float GravitationGunSmooth;
    public float rotSpeed;
    public bool gravityGun;
    public bool jetpack;
    public SpriteRenderer sprite;
    [Header("Camera")]
    public float smooth;
    private Camera cam;
    [Space]
    public float xMin;
    public float xMax, yMin, yMax;
    [Space]
    public float OffsetX;
    public float OffsetY, OffsetYMin, OffsetYMax;
    [Header("Movement")]
    public float moveS;
    public float jumpF, slowC, controlC, Sslow, jumpCoolDown;
    [Header("Checkers")]
    public Transform checker1P;
    public Transform checker2P, checker3P, checker4P , checker5P;
    [Header("LayerMasks")]
    public LayerMask checker1L;
    public LayerMask checker2L, checker3L, checker4L, checker5L;

    Vector3 campos, fincampos;
    [HideInInspector]
    public int CurW;
    private int slideMoveS;
    private float timer2, FOffsetY;
    private bool checker1, checker2, checker3, checker4, checker5, groundedA, left, up, slide, slideMove, wallJ;
    Rigidbody2D rb2d;
    Animator anim;

    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        anim = this.GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        CurW = 1;
        cam.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -10);
    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Restart")) SceneManager.LoadScene("test");
        Movement();
        Action();
        Visualisation();
    }

    void SlideMoveStarted()
    {
        if (left) slideMoveS = 1; else slideMoveS = 2;
    }

    void Movement()
    {
        sprite.gameObject.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 1);
        checker1 = Physics2D.OverlapCircle(checker1P.position, 0.01f, checker1L);
        checker2 = Physics2D.OverlapCircle(checker2P.position, 0.01f, checker2L);
        checker3 = Physics2D.OverlapCircle(checker3P.position, 0.01f, checker3L);
        checker4 = Physics2D.OverlapCircle(checker4P.position, 0.01f, checker4L);
        checker5 = Physics2D.OverlapCircle(checker5P.position, 0.01f, checker5L);
        groundedA = checker3 && rb2d.velocity.y < 0;
        wallJ = checker1 && checker4 && !checker2 && !checker3;
        timer2 += Time.deltaTime;
        if (timer2 < jumpCoolDown / 2) wallJ = false; 
        if (checker2 || wallJ) if (!slide) { rb2d.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveS, rb2d.velocity.y); slideMove = false; }
            else
            {
                if (rb2d.velocity.x > Sslow && !slideMove) rb2d.velocity = new Vector2(rb2d.velocity.x - Sslow, rb2d.velocity.y);
                else if (rb2d.velocity.x < -Sslow && !slideMove) rb2d.velocity = new Vector2(rb2d.velocity.x + Sslow, rb2d.velocity.y);
                else slideMove = true;
            }
        else if (rb2d.velocity.x < moveS && rb2d.velocity.x > -moveS) rb2d.velocity = rb2d.velocity + new Vector2(Input.GetAxisRaw("Horizontal") * moveS / controlC, 0);
        if (!checker2)
        {
            if (rb2d.velocity.x > slowC) rb2d.velocity = new Vector2(rb2d.velocity.x - slowC, rb2d.velocity.y);
            if (rb2d.velocity.x < -slowC) rb2d.velocity = new Vector2(rb2d.velocity.x + slowC, rb2d.velocity.y);
        }
        if (!checker1 && checker4 && checker2) slide = true;
        if (!checker4 && !checker5) slide = false;
        if (Input.GetButton("Jump") && !slide)
        {
            if (checker2 && timer2 > jumpCoolDown && rb2d.velocity.y == 0)
            {
                rb2d.AddForce(new Vector2(0, jumpF * rb2d.mass * -Physics2D.gravity.y), ForceMode2D.Impulse);
                timer2 = 0;
            }
            else if(wallJ && timer2 > jumpCoolDown && rb2d.velocity.y == 0 && Input.GetAxisRaw("Horizontal") !=0)
            {
                wallJ = false;
                rb2d.AddForce(new Vector2(Input.GetAxisRaw("Horizontal") * rb2d.mass, jumpF * rb2d.mass * -Physics2D.gravity.y), ForceMode2D.Impulse);
                timer2 = 0;
            }
            else if (jetpack);
        }
        if (slideMove)
        {
            rb2d.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveS / 6, rb2d.velocity.y);
            if (rb2d.velocity.x != 0) anim.SetBool("slideMove", true); else anim.SetBool("slideMove", false);
        }
        if (wallJ) if (!Input.GetButton("Down")) { rb2d.velocity = Vector2.zero; rb2d.AddForce(new Vector2(0, rb2d.mass * -Physics2D.gravity.y), ForceMode2D.Force); } else rb2d.velocity = new Vector2(rb2d.velocity.x, Mathf.Clamp(rb2d.velocity.y, -7, 0));
    }

    void Action()
    {
        if (Input.GetButtonDown("ChangeWeapon"))
            if (gravityGun && CurW == 1)
            {
                CurW = 2;
                sprite.gameObject.transform.localScale = new Vector3((GravitationGunRadius - 10) * 9, (GravitationGunRadius - 10) * 9, 1);
            }
            else
            {
                CurW = 1;
                sprite.gameObject.transform.localScale = new Vector3((GravitationGunRadius - 10) * 9, (GravitationGunRadius - 10) * 9, 1);
            }
        if (CurW == 2) sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.3f);
        else sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0);
        /*if (CurW == 1)
        {
            if (Input.GetButtonDown("Use") && checker2) anim.SetTrigger("useW1_G");
            if (Input.GetButton("Use") && Input.GetButton("Down") && groundedA && rb2d.velocity.y < 0) anim.SetBool("useW1_GA", true); else anim.SetBool("useW1_GA", false);
            if (Input.GetButtonDown("Use") && !Input.GetButton("Down") && !groundedA && !checker2) anim.SetTrigger("useW1_A");
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsTag("AttackG") || anim.GetCurrentAnimatorStateInfo(0).IsTag("AttackGA") && checker2 || anim.GetCurrentAnimatorStateInfo(0).IsTag("AttackA")) {
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(new Vector2(0, rb2d.mass * -Physics2D.gravity.y), ForceMode2D.Force);
        }*/
    }

    void Visualisation()
    {
        if (!slide) slideMoveS = 0;
        if (rb2d.velocity.x != 0 && !wallJ) anim.SetBool("run", true); else anim.SetBool("run", false);
        if (Input.GetButton("Jump")) anim.SetBool("jumpPressed", true); else anim.SetBool("jumpPressed", false);
        anim.SetBool("grounded", checker2);
        anim.SetBool("jumpExit", groundedA);
        anim.SetBool("slide", slide);
        anim.SetBool("walljump", wallJ);
        if (rb2d.velocity.x < 0)
        {
            if (!slideMove) this.transform.rotation = Quaternion.Euler(0, 180, 0);
            else if (slideMoveS != 0 && slideMoveS != 1) anim.SetFloat("slideMoveS", -0.9f);
            left = false;
        }
        if (rb2d.velocity.x > 0)
        {
            if (!slideMove) this.transform.rotation = Quaternion.Euler(0, 0, 0);
            else if (slideMoveS != 0 && slideMoveS != 2) anim.SetFloat("slideMoveS", -0.9f);
            left = true;
        }
        FOffsetY = OffsetY * rb2d.velocity.y * 0.3f;
        FOffsetY = Mathf.Clamp(FOffsetY, OffsetYMin, OffsetYMax);
        campos = new Vector3(Mathf.Clamp(this.transform.position.x, xMin, xMax), Mathf.Clamp(this.transform.position.y, yMin, yMax), cam.transform.position.z);
        if (left) fincampos = Vector3.Lerp(cam.transform.position, new Vector3(campos.x + OffsetX, Mathf.Clamp(campos.y + FOffsetY, yMin, yMax), campos.z), Time.deltaTime * smooth);
        else fincampos = Vector3.Lerp(cam.transform.position, new Vector3(campos.x - OffsetX, Mathf.Clamp(campos.y + FOffsetY, yMin, yMax), campos.z), Time.deltaTime * smooth);
        cam.transform.position = fincampos;  
    }
}
