using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public Transform target;
	public float smoothing = 5f;
	
	Vector3 shift;

	// Use this for initialization
	void Start () {
		shift = transform.position - target.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 newCamPosition = target.position + shift;
		this.transform.position = Vector3.Lerp (transform.position, newCamPosition, smoothing * Time.deltaTime);
	}
}
