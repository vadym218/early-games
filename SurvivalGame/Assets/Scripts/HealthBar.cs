using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

    public Animator healthanim, staminaanim;
    public float stamina, health;

	void Start () {
	
	}
	
	void Update () {
        stamina = CharacterControl.staminas;
        health = CharacterControl.staminas;
        staminaanim.Play("Stamina", 0, (100-stamina)/101);
        healthanim.Play("Health", 0, (100-health)/101);
    }
}
