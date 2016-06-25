using UnityEngine;
using System.Collections;

public class RayShooter : MonoBehaviour {
	private Camera playerCamera;

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

				if (target != null) {
					target.ReactToHit();
				} else {
					StartCoroutine(SphereIndicator(hit.point)); //pass in a method call to start running
				}
			}
		}
	}

	private IEnumerator SphereIndicator(Vector3 pos) {
		GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		sphere.transform.position = pos;

		yield return new WaitForSeconds(1); //yield tells coroutine where to pause game and run next frame etc
		//called function runs until it hits a yield

		Destroy(sphere);
	}
}
