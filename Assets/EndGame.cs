using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {
	public float survival;
	public void setSurvival(float surv){
		survival=surv;
	}

	// Use this for initialization
	void Start () {
		survival=Player.getSurvival();
		Time.timeScale=0;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D collision){
		Destroy(collision.gameObject);

	}
	void OnGUI(){
		GUI.Box(new Rect(Screen.width/2-100,Screen.height/2-50,200,100),"GAME OVER: \n YOU SURVIVED FOR \n"+survival+" SECONDS");
		if(GUI.Button (new Rect(Screen.width/2-100,Screen.height/2+50,200,50), "Main menu")) {
			Application.LoadLevel (0);
		}
	}
}
