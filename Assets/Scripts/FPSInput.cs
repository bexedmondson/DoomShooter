using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour {
	private CharacterController charController;
	public float gravity = -3f;
	public float speed = 6.0f;

	private Animator staffAnimator;

	void Start() {
		charController = GetComponent<CharacterController>();

		staffAnimator = GameObject.FindWithTag("staff").GetComponent<Animator>();
	}

	void Update() {
		float deltaX = Input.GetAxis("Horizontal") * speed;
		float deltaZ = Input.GetAxis("Vertical") * speed;
		Vector3 movement = new Vector3(deltaX, 0, deltaZ);
		movement = Vector3.ClampMagnitude(movement, speed);

		movement *= Time.deltaTime;
		movement.y = gravity;
		movement = transform.TransformDirection(movement);
		charController.Move(movement);

		if (movement.x != 0 || movement.z != 0) {
			staffAnimator.SetBool("Walking", true);
		} else {
			staffAnimator.SetBool("Walking", false);
		}
	}
}
