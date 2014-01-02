using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {
	public float survival;
	private float time = 0;
	private bool isBlackHole = false;
	public GameObject blackHole;
	public void setSurvival(float surv){
		survival=surv;
	}

	// Use this for initialization
	void Start () {
		survival=Player.getSurvival();
		//Time.timeScale=0;

	
	}
	
	// Update is called once per frame
	void Update () {
		if (isBlackHole == false) {
						if (time < 1) {
								time += Time.deltaTime;
						} else {
								isBlackHole = true;
								Instantiate (blackHole, transform.position, transform.rotation);
						}
				}
	}
	void OnCollisionEnter2D(Collision2D collision){
		Destroy(collision.gameObject);

	}
	void OnGUI(){
		GUI.Box(new Rect(Screen.width/2-100,Screen.height/4-50,200,100),"GAME OVER: \n YOU SURVIVED FOR \n"+survival+" SECONDS");
		if(GUI.Button (new Rect(Screen.width/2-100,Screen.height/4+50,200,50), "Main menu")) {
			Application.LoadLevel (0);
		}
	}
}
