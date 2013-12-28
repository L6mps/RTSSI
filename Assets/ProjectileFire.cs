using UnityEngine;
using System.Collections;

public class ProjectileFire : MonoBehaviour {
	public float speed=100;
	public float angle;

	// Use this for initialization
	void Start () {

		Physics2D.IgnoreLayerCollision (9, 9, true);
		angle=(360-transform.rotation.eulerAngles.z)*Mathf.Deg2Rad;
		Vector2 newVelocity=Vector2.zero;
		float sin=Mathf.Sin (angle);
		float cos=Mathf.Cos (angle);
		newVelocity.x=sin*speed;
		newVelocity.y=cos*speed;
		rigidbody2D.velocity=newVelocity;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(){

				Destroy (gameObject);
		}
}
