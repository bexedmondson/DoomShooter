using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {
	public float speed = 10.0f;
	public int damage = 1;

	[SerializeField] private GameObject flamesPrefab;
	private GameObject flames;

	void Start() {
		flames = Instantiate(flamesPrefab) as GameObject;

		flames.transform.position = transform.position;

		Quaternion flameRotation = transform.rotation;
		flameRotation.z = -transform.rotation.z;
		flames.transform.rotation = flameRotation; //point fireball in opposite direction
	}

	void Update () {
		transform.Translate(0, 0, speed * Time.deltaTime);
		flames.transform.Translate(0, 0, speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other) {
		PlayerCharacter player = other.GetComponent<PlayerCharacter>();
		if (player != null) {
			player.Hurt(damage);
		}

		Destroy(flames.gameObject);
		Destroy(this.gameObject);
	}
}
