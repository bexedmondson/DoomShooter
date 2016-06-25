using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {
    public enum RotationAxes {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxes axes = RotationAxes.MouseXAndY;

	public float sensitivityH = 9.0f;
	public float sensitivityV = 9.0f;

	public float minV = -45.0f;
	public float maxV = 45.0f;

	private float rotationX = 0;

	void Start() {
		Rigidbody body = GetComponent<Rigidbody>();

		if (body != null) {
			body.freezeRotation = true;
		}
	}

	void Update() {
	    if (axes == RotationAxes.MouseX) {
		transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityH, 0);
        }
        else if (axes == RotationAxes.MouseY){
			rotationX -= Input.GetAxis("Mouse Y") * sensitivityV;
			rotationX = Mathf.Clamp(rotationX, minV, maxV);

			float rotationY = transform.localEulerAngles.y;

			transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
        }
        else {
			rotationX -= Input.GetAxis("Mouse Y") * sensitivityV;
			rotationX = Mathf.Clamp(rotationX, minV, maxV);

			float delta = Input.GetAxis("Mouse X") * sensitivityH;
			float rotationY = transform.localEulerAngles.y + delta;

			transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
        }
	}
}
