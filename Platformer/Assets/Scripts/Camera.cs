using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

    public Transform Target;
    public float CameraSpeed = 0.125f;
    public Vector3 ofset = new Vector3(3, 5, -30f);

	void Update () {
        Vector3 desiredPosition = Target.transform.position + ofset;
        transform.position = desiredPosition;
	}
}
