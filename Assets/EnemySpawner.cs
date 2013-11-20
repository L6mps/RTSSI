using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemy;
	public float offset = 100f;

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp("s")) {
			Vector3 newPos = transform.position;
			Vector2 newRand = Random.insideUnitCircle;
			newPos.x += offset*newRand.x;
			newPos.y += offset*newRand.y;
			Instantiate(enemy, newPos, Quaternion.identity);
		}
	}
}