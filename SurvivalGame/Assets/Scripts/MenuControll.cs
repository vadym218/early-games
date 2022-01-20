using UnityEngine;
using System.Collections;

public class MenuControll : MonoBehaviour {

    private Animator menu;
    private bool menuopen,esc,map,inv,craft;
    public static bool escs,menuopens;
    private float timer;

	void Start () {
        menu = GetComponent<Animator>();
	}
	
	void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetButtonUp("Cancel")) if (esc)
            {
                esc = false;
                Time.timeScale = 1.0f;
            }
        else
            {
                esc = true;
                timer = 0;
            }
        if (timer > 2 && esc) Time.timeScale = 0.0f; else Time.timeScale = 1f;
        if (menuopen) Cursor.visible = true; else Cursor.visible = false;
        if (escs == false) { esc = escs; escs = true; }
        menuopens = menuopen;
        menuopen = esc || map || inv || craft;
        menu.SetBool("MenuOpen", menuopen);
        menu.SetBool("Esc", esc);
    }
}
