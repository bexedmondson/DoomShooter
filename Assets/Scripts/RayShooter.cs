using UnityEngine;
using System.Collections;

public class RayShooter : MonoBehaviour {
	private Camera playerCamera;

	[SerializeField] private GameObject fireballPrefab;
	private GameObject fireball;

	void Start () {
		playerCamera = GetComponent<Camera>();

		Cursor.lockState = CursorLockMode.Locked; //put cursor at screen centre
		Cursor.visible = false; //hide cursor
	}

	void OnGUI() {
		int size = 12;
		float posX = playerCamera.pixelWidth / 2 - size / 4;
		float posY = playerCamera.pixelHeight / 2 - size / 2;

		GUI.Label(new Rect(posX, posY, size, size), "*");
	}

	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			Vector3 point = new Vector3(playerCamera.pixelWidth / 2, playerCamera.pixelHeight / 2, 0); //get screen centre
			Ray ray = playerCamera.ScreenPointToRay(point); //create ray at screen centre

			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) { //out is c# syntax that ensures hit is passed directly into the method rather than as a copy
				GameObject hitObject = hit.transform.gameObject;

				ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();

				fireball = Instantiate(fireballPrefab) as GameObject;
				fireball.transform.position = transform.TransformPoint(Vector3.forward * 2f); //place fireball in front of shooter
				fireball.transform.rotation = transform.rotation; //point fireball in same direction

				if (target != null) {
					target.ReactToHit();
				}
			}
		}
	}
}
