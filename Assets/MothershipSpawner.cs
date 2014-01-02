using UnityEngine;
using System.Collections;

public class MothershipSpawner : MonoBehaviour {
	public GameObject enemy;
	public float offset = 100f;
	public float mothershipSpawnDelay = 15f;
	public float relocateDelay = 60f;
	//public int maxMotherships = 4;
	//private int mothershipsLeft;
	//private int health=20;
	public float speed=10;
	//private float radius;

	void Start() {
		//mothershipsLeft = maxMotherships;
		//radius=Mathf.Sqrt (Mathf.Pow (transform.position.x,2)+Mathf.Pow (transform.position.y,2));
	}

	void Update () {
		if(!IsInvoking())
			Invoke ("SpawnMothership", mothershipSpawnDelay);
		//debug code, s for mothership
		if(Input.GetKeyUp("s")) {
			SpawnMothership ();
		}
		orbit ();
	}
	void orbit(){
		transform.position=Quaternion.Euler (0,0,1*Time.deltaTime*speed)*transform.position;
	}

	void SpawnMothership() {
		Vector3 newPos = transform.position;
		Vector2 newRand = Random.insideUnitCircle;
		newPos.x += offset*newRand.x;
		newPos.y += offset*newRand.y;
		Instantiate(enemy, newPos, Quaternion.identity);
		//mothershipsLeft--;
		//if(mothershipsLeft < 1)
		//	Invoke ("Relocate", relocateDelay);
	}

	void Relocate() {
		Vector2 randomPos = new Vector2(0,0);
		while(Mathf.Sqrt(randomPos.x*randomPos.x + randomPos.y*randomPos.y)<PortalSpawner.minPortalDistance)
			randomPos = Random.insideUnitCircle * PortalSpawner.maxPortalDistance;
		Vector3 newPos = new Vector3(randomPos.x, randomPos.y, 0);
		this.gameObject.transform.position = newPos;
	}
}