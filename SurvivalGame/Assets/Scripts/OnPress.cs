using UnityEngine;
using System.Collections;

public class OnPress : MonoBehaviour {

    public Animator anim;
    private bool settings;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetButtonUp("Cancel") && settings)
        {
            settings = false;
            anim.SetBool("Settings", settings);
        }
    }

    public void OnPressPlay()
    {
        Application.LoadLevel("test");
        Cursor.visible = false;
    }

    public void OnPressQuit()
    {
        Application.Quit();
    }

    public void OnPressBTG()
    {
        MenuControll.escs = false;
    }

    public void OnPressMM()
    {
        Application.LoadLevel("MainMenu");
    }

    public void OnPressSettings()
    {
        if (settings)
        {
            settings = false;
            anim.SetBool("Settings", settings);
        }
        else
        {
            settings = true;
            anim.SetBool("Settings", settings);
        }
    }
}
