using UnityEngine;
using System.Collections;

public class WanderingAI : MonoBehaviour {
	public float speed = 3.0f;
	public float obstacleRange = 5.0f;
	private bool alive;

	[SerializeField] private GameObject fireballPrefab;
	private GameObject fireball;

	void Start() {
		alive = true;
	}

	void Update() {
		if (alive) {
			transform.Translate(0, 0, speed * Time.deltaTime);

			Ray ray = new Ray(transform.position, transform.forward);
			RaycastHit hit;
			if (Physics.SphereCast(ray, 0.75f, out hit)) {
				GameObject hitObject = hit.transform.gameObject;

				if (hitObject.GetComponent<PlayerCharacter>()) {
					
					if (fireball == null) {
					fireball = Instantiate(fireballPrefab) as GameObject;
					fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f); //place fireball in front of enemy
					fireball.transform.rotation = transform.rotation; //point fireball in same direction
					}

				} else if (hit.distance < obstacleRange) {
					transform.Rotate(0, Random.Range(-110, 110), 0);
				}
			}
		}
	}

	public void Kill() {
		alive = false;
	}
}
