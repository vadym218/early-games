using UnityEngine;
using System.Collections;

public class DayNight : MonoBehaviour
{
    [Header("GeneralSettings")]
    [Space]
    public float daySpeed;
    [Header("Time")]
    [Space]
    public float cursec;
    public float curmin;
    public float curhoure;

    private int StartTime, StartTimeRef = 5;
    private float n1, n2, timer, curhour, allsec;
    private bool lastn, lower;
    private Color last, cur;

    void Start() { 
        StartTime = StartTimeRef;
    }

    void Update()
    {
        if(allsec > 86400)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        if (allsec / 3600 + StartTimeRef > 24) StartTime = -24 + StartTimeRef;

        if (timer < 0.01f)
        {
            n1 = transform.rotation.x;
            lastn = true;
        }
        else
        {
            n2 = transform.rotation.x;
            lastn = false;
            timer = 0;
        }
        timer += Time.deltaTime;

        transform.RotateAround(transform.position, transform.right, daySpeed * Time.deltaTime);

        if (lastn) if (n1 < n2) lower = false; else lower = true;

        if (lower)
        {
            allsec = transform.rotation.x * 43200;
            StartTime = StartTimeRef;
        }
        else allsec = 43200 + (1 - transform.rotation.x) * 43200;

        curhoure = Mathf.RoundToInt(curhour + StartTime);
        curhour = Mathf.FloorToInt(allsec / 3600);
        curmin = Mathf.FloorToInt((allsec - curhour * 3600) / 60);
        cursec = Mathf.FloorToInt(allsec - (curmin * 60 + curhour * 3600));
    }

}