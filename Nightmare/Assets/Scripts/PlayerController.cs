using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public int speed = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float horizontal = Input.GetAxisRaw ("Horizontal");
		float vertical = Input.GetAxisRaw ("Vertical");
		bool jump = Input.GetKey (KeyCode.Space);

		Vector3 force = new Vector3 (horizontal, 0, vertical);
		rigidbody.MovePosition (rigidbody.position + force * speed * Time.deltaTime);

		if(jump)
		{
			Vector3 jumpForce = new Vector3 (0, 1);
			rigidbody.AddForce(jumpForce * speed * Time.deltaTime);
		}
	}
}
