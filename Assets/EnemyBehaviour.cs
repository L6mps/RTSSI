using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
	public float speed = 0.5f;
	
	// Use this for initialization
	void Start () {
		velocityTowardsPlanet();
	}
	
	void velocityTowardsPlanet() {
		float xSpeed = -speed*transform.position.x;
		float ySpeed = -speed*transform.position.y;
		Vector2 velocity = new Vector2(xSpeed, ySpeed);
		rigidbody2D.velocity = velocity;
	}
	void OnCollisionEnter2D(Collision2D collision){
		Physics2D.IgnoreLayerCollision (8, 8, true);
		Destroy (gameObject);
	}
}