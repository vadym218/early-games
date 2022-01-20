using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuControl : MonoBehaviour
{

    public float minX, maxX, minY, maxY, xClamp, minxClamp, maxxClamp, clampxMult, sensivity, smooth, colorChangeSmooth, audioPcolor, qualityPcolor, languagePcolor, audioS, qualityS, languageS;
    public Image quality, audio, language;
    private float rotationX, rotationY, rotationXvelocity, rotationYvelocity, currotationX, currotationY;
    private Camera cam;

    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        CamRotation();
    }

    void CamRotation()
    {
        if (currotationY > audioS) audio.color = Color.Lerp(audio.color, new Color(audio.color.r, audio.color.g, audio.color.b, audioPcolor), Time.deltaTime * colorChangeSmooth);
        else audio.color = Color.Lerp(audio.color, new Color(audio.color.r, audio.color.g, audio.color.b, 0), Time.deltaTime * colorChangeSmooth * 3);
        if (currotationY > qualityS) quality.color = Color.Lerp(quality.color, new Color(quality.color.r, quality.color.g, quality.color.b, qualityPcolor), Time.deltaTime * colorChangeSmooth);
        else quality.color = Color.Lerp(quality.color, new Color(quality.color.r, quality.color.g, quality.color.b, 0), Time.deltaTime * colorChangeSmooth * 3);
        if (currotationY > languageS) language.color = Color.Lerp(language.color, new Color(language.color.r, language.color.g, language.color.b, languagePcolor), Time.deltaTime * colorChangeSmooth);
        else language.color = Color.Lerp(language.color, new Color(language.color.r, language.color.g, language.color.b, 0), Time.deltaTime * colorChangeSmooth * 3);
        audio.color = Color.Lerp(audio.color, new Color(audio.color.r, audio.color.g, audio.color.b, 0), Time.deltaTime / colorChangeSmooth);
        if (!(currotationY > xClamp))
        {
            rotationX += Input.GetAxis("Mouse Y") * sensivity;
            rotationY += Input.GetAxis("Mouse X") * sensivity;
            rotationX = Mathf.Clamp(rotationX, minX, maxX);
            currotationX = Mathf.SmoothDamp(currotationX, rotationX, ref rotationXvelocity, smooth);
        }
        else
        {
            rotationX += Input.GetAxis("Mouse Y") * sensivity / 2;
            rotationY += Input.GetAxis("Mouse X") * sensivity / 2;
            rotationX = Mathf.Clamp(rotationX, minxClamp, maxxClamp);
            currotationX = Mathf.SmoothDamp(currotationX, rotationX, ref rotationXvelocity, smooth * clampxMult);
        }
        rotationY = Mathf.Clamp(rotationY, minY, maxY);

        currotationY = Mathf.SmoothDamp(currotationY, rotationY, ref rotationYvelocity, smooth);

        cam.transform.rotation = Quaternion.Euler(currotationX, currotationY, 0);
    }

    public void Play()
    {
        SceneManager.LoadSceneAsync("");
    }

    public void Exit()
    {
        Application.Quit();
    }

}
