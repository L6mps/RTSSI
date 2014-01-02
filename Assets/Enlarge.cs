using UnityEngine;
using System.Collections;

public class Enlarge : MonoBehaviour {
	private Vector3 target=new Vector3(1,1,1);
	private Vector3 from;
	private float step=0;

	// Use this for initialization
	void Start () {
		from = transform.localScale;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.localScale != target) {
						if (transform.localScale.x < target.x) {
				step+=0.2f*Time.deltaTime;
								transform.localScale = Vector3.Lerp (from, target, step);
						} else {
								transform.localScale = target;
						}
				}

	
	}
}
