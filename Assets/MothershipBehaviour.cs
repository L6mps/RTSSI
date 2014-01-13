using UnityEngine;
using System.Collections;

public class MothershipBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.transform.LookAt(new Vector3(0,0,0), Vector3.back);
		Player.mothershipCount++;
	}
	
	// Update is called once per frame
	void Update () {

	
	}
}
