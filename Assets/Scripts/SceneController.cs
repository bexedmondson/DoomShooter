using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {
	[SerializeField] private GameObject enemyPrefab;
	private GameObject enemy; //only one enemy at a time, private so prefab visible to editor but not editable by other scripts

	void Update () {
		if (enemy == null) {
			enemy = Instantiate(enemyPrefab) as GameObject; //create copy of prefab in scene
			enemy.transform.position = new Vector3(0, 0, 0);
			enemy.transform.Rotate(0, Random.Range(0, 360), 0);
		}
	}
}
