using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour {
	private int health;

	void Start() {
		health = 5;
	}

	public void Hurt(int damage) {
		health -= damage;
		Debug.Log("Health: " + health);
	}
}
