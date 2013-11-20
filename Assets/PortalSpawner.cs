using UnityEngine;
using System.Collections;

public class PortalSpawner : MonoBehaviour {
	
	public GameObject portal;
	public int minPortalDistance = 1000;
	public int maxPortalDistance = 4000;

	// Update is called once per frame
	void Update () { 
		if(Input.GetKeyUp ("a")) {
			Vector2 randomPos = new Vector2(0,0);
			while(Mathf.Sqrt(randomPos.x*randomPos.x + randomPos.y*randomPos.y)<minPortalDistance)
				randomPos = Random.insideUnitCircle * maxPortalDistance;
			Vector3 newPos = new Vector3(randomPos.x, randomPos.y, 0);
			Instantiate (portal, newPos,new Quaternion(0,0,0,0));
		}
	}
}
