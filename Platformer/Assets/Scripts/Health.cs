using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{

    public Move move;
    public float timer = 1;
    public int starthealth;
    public int health;
    private Transform[] hearts = new Transform[5];

    void Start()
    {
        health = starthealth;
    }

    void Update()
    {
        if (health > 5)
        {
            health = 5;
        }
        if (move.Die)
        {
            if (timer < 0)
            {
                timer = 1;
                health = health - Random.Range(1,4);
            }           
        }
        timer -= Time.deltaTime;
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i] = transform.GetChild(i);
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (health > i)
            {
                hearts[i].gameObject.SetActive(true);
            }
            else
            {
                hearts[i].gameObject.SetActive(false);
            }
        }


    }
}