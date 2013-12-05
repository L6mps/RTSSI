using UnityEngine;
using System.Collections;

public class PortalSpawner : MonoBehaviour {
	
	public GameObject portal;
	public static float minPortalDistance = 1000f;
	public static float maxPortalDistance = 4000f;
	public float portalSpawnRate = 60f;

	// Update is called once per frame
	void Update () { 
		if(!IsInvoking())
			Invoke ("SpawnPortal", portalSpawnRate);

		//debug code, press a to spawn a portal
		if(Input.GetKeyUp ("a")) {
			SpawnPortal();
		}
	}

	void SpawnPortal() {
		Vector2 randomPos = new Vector2(0,0);
		while(Mathf.Sqrt(randomPos.x*randomPos.x + randomPos.y*randomPos.y)<minPortalDistance)
			randomPos = Random.insideUnitCircle * maxPortalDistance;
		Vector3 newPos = new Vector3(randomPos.x, randomPos.y, 0);
		Instantiate (portal, newPos, new Quaternion(0,0,0,0));
	}
}
