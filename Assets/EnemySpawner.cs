using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemy;
	public float offset = 50f;
	public float EnemySpawnDelay = 8f;
	public int maxEnemies = 100;
	private int enemiesLeft;
	
	void Start() {
		enemiesLeft = maxEnemies;
	}

	void Update () {
		if(!IsInvoking() && enemiesLeft>0)
			Invoke ("SpawnEnemy", EnemySpawnDelay);
		//debug code, d for enemies
		if(Input.GetKeyUp("d")) {
			SpawnEnemy ();
		}
	}
	
	void SpawnEnemy() {
		for(int i=0; i<5; i++) {
			Vector3 newPos = transform.position;
			Vector2 newRand = Random.insideUnitCircle;
			newPos.x += offset*newRand.x;
			newPos.y += offset*newRand.y;
			Instantiate(enemy, newPos, Quaternion.identity);
		}
		maxEnemies-=5;
	}
}