using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour {

    public float speed = 10.0f, sensivity = 10.0f, smooth = 2, jumpheight = 20.0f, curspeed, curjumpheight,stamina;
    private float strtheight = 2, curheight, timer=0;
    public static float staminas,sensivitys=10.0f;
    private bool crouch, isGrounded, pressC,run,canjump;
    public bool canmove;
    private Rigidbody rb;
    public GameObject camera,cameracontroller;
    Vector3 movement, rotation;
    CapsuleCollider playercol;
    Animator anim;



    void Start() {
        Cursor.visible = false;
        anim = cameracontroller.GetComponent<Animator>();
        playercol = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
        curspeed = speed;
        crouch = false;
    }
    void FixedUpdate() {
        sensivity = sensivitys;
        canmove = !MenuControll.menuopens;
        staminas = stamina;
        HealthAndArmor();
        Move();
        Rotation();
        Animation();
    }
    void HealthAndArmor()
    {

    }
    void Rotation()
    {
        if (canmove)
        {
            Vector3 addrotation = new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
            rotation.y = Mathf.Lerp(rotation.y, rotation.y + addrotation.y * sensivity, 1 / smooth);
            rotation.x = Mathf.Lerp(rotation.x, rotation.x + addrotation.x * sensivity, 1 / smooth);
            camera.transform.localEulerAngles = new Vector3(Mathf.Clamp(rotation.x, -85, 65), 0, 0);
            transform.localEulerAngles = new Vector3(0, rotation.y, 0);
            rotation.x = Mathf.Clamp(rotation.x, -85, 65);
        }
    }
    void Move()
    {
        if (timer < 3) timer += Time.deltaTime; if (timer >= 3) canjump = true;
        pressC = Input.GetButton("Crouch");
        crouch = !Physics.Raycast(transform.position, Vector3.up, playercol.height + 0.1f);
        run = Input.GetKey(KeyCode.LeftShift) && stamina >= 5;
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1);
        if (pressC && canmove) { curheight = strtheight / 2.5f; curspeed = speed; curjumpheight = jumpheight / 2; }
        else { if (crouch) { curheight = strtheight; curjumpheight = jumpheight; } if (run) curspeed = speed * 3; else curspeed = speed * 2; }
        playercol.height = curheight;
        if (stamina >= 5) curjumpheight = jumpheight; else curjumpheight = 0;
        movement = transform.TransformDirection(Input.GetAxis("Horizontal") * curspeed,0, Input.GetAxis("Vertical") * curspeed);
        if (isGrounded && Input.GetButtonDown("Jump")&& canjump && pressC == false && stamina>=5 && canmove)
        {
            rb.AddForce(Vector3.up * curjumpheight, ForceMode.Impulse);
            stamina -= 5;
            canjump = false;
            timer = 0;
        }
        if (run) stamina -= 3*Time.deltaTime;
        stamina += 0.5f*Time.deltaTime;
        stamina = Mathf.Clamp(stamina, 0, 100);
        movement = movement * Time.deltaTime;
        if (canmove) rb.MovePosition(transform.position + movement);
    }
    void Animation()
    {
        if (isGrounded==false) anim.SetBool("Jump", true); else anim.SetBool("Jump", false);
        if (isGrounded == true && canmove && Input.GetButton("Vertical") || isGrounded == true && canmove && Input.GetButton("Horizontal"))
        {
            if (run)
            {
                anim.SetBool("Walk", true); anim.SetFloat("Speed", 2);
            }
            else
            {
                anim.SetBool("Walk", true); anim.SetFloat("Speed", 1);
            }
        }
        else
        {
            anim.SetBool("Walk", false); anim.SetFloat("Speed", 1);
        }
        if (anim.GetBool("Walk") == false && anim.GetBool("Jump") == false) anim.SetBool("Idle", true); else anim.SetBool("Idle", false);
    }
}

