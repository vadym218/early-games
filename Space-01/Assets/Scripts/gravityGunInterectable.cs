using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class gravityGunInterectable : MonoBehaviour {

    Rigidbody2D rb2d;
    private GameObject character;
    private Vector3 pos, lastPos, offset;
    private Camera cam;
    private bool mouseDownOver = true;
    private float smooth, gravity, rotSpeed;
    private LayerMask layer;
    private SpriteRenderer sprite;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        character = GameObject.FindGameObjectWithTag("Player");
    }

    void OnMouseDown()
    {
        rotSpeed = character.GetComponent<character>().rotSpeed;
        smooth = character.GetComponent<character>().GravitationGunSmooth;
        gravity = rb2d.gravityScale;
        layer = this.gameObject.layer;
        if ((character.transform.position - cam.ScreenToWorldPoint(Input.mousePosition)).magnitude < character.GetComponent<character>().GravitationGunRadius && character.GetComponent<character>().CurW == 2) offset = this.transform.position - cam.ScreenToWorldPoint(Input.mousePosition);
        else mouseDownOver = false;
    }

    void OnMouseUp()
    {
        if((character.transform.position - (this.transform.position - offset)).magnitude < character.GetComponent<character>().GravitationGunRadius) rb2d.velocity = (pos - lastPos) * 15;
        this.gameObject.layer = layer;
        rb2d.gravityScale = gravity;
        mouseDownOver = true;
        
    }

    void OnMouseDrag()
    {
        if ((character.transform.position - (this.transform.position - offset)).magnitude < character.GetComponent<character>().GravitationGunRadius && mouseDownOver && character.GetComponent<character>().CurW == 2)
        {
            lastPos = pos;
            pos = this.transform.position;
            character.GetComponent<character>().sprite.color = new Color(255, 255, 255, 255);
            this.gameObject.layer = 0;
            rb2d.gravityScale = 0;
            rb2d.MovePosition(Vector3.Lerp(this.transform.position, cam.ScreenToWorldPoint(Input.mousePosition) + offset, Time.deltaTime * smooth));
        }
        else
        {
            if(mouseDownOver)rb2d.velocity = (pos - lastPos) * 10;
            this.gameObject.layer = layer;
            rb2d.gravityScale = gravity;
            mouseDownOver = false;
        }
    }
}