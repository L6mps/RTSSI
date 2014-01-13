using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
	public float speed = 0.5f;
	public GameObject explosion;
	
	// Use this for initialization
	void Start () {
		Player.kamikazeCount++;
		velocityTowardsPlanet();
		this.transform.LookAt(new Vector3(0,0,0), Vector3.back);
	}
	
	void velocityTowardsPlanet() {
		float xSpeed = -speed*transform.position.x;
		float ySpeed = -speed*transform.position.y;
		Vector2 velocity = new Vector2(xSpeed, ySpeed);
		rigidbody2D.velocity = velocity;
	}
	void OnCollisionEnter2D(Collision2D collision){
		Physics2D.IgnoreLayerCollision (8, 8, true);
		Instantiate (explosion,transform.position,transform.rotation);
		Destroy (gameObject);
		Player.kamikazeCount--;
	}
}