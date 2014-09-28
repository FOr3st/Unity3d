using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 5f;

	Animator animator;
	Rigidbody playerRigidBody;
	int floorMaskIndex;
	Vector3 movement;
	float cameraRayLength = 100f;

	void Awake()
	{
		floorMaskIndex = LayerMask.GetMask ("Floor");
		animator = GetComponent<Animator>();
		playerRigidBody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate()
	{
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		move (h, v);
		rotate ();

		animate (h, v);
	}

	void move(float h, float v)
	{
		movement.Set(h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;
		playerRigidBody.MovePosition(transform.position + movement);
	}

	void rotate ()
	{
		Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit rayHit;

		bool hit;

		hit = Physics.Raycast (cameraRay, out rayHit, cameraRayLength, floorMaskIndex);
		if (hit) 
		{
			Vector3 direction = rayHit.point - transform.position;
			direction.y = 0f;

			Quaternion rotation = Quaternion.LookRotation(direction);
			playerRigidBody.MoveRotation(rotation);
		}
	}

	void animate(float h, float v)
	{
		bool isWalking = h != 0f || v != 0f;
		animator.SetBool ("IsWalking", isWalking);
	}
}


