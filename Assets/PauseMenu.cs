using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public GUIStyle sty;
	private bool paused = false;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp ("escape")) {
			if(paused) {
				paused = false;
				Time.timeScale=1;
			}
			else {
				paused = true;
				Time.timeScale=0;
			}
		}
	}
	
	void OnGUI() {
		if(paused) {
			int x1 = Screen.width/2 - Screen.width/8;
			int xLen = Screen.width/4;
			int y1 = Screen.height/2 - Screen.width/8;
			int yStep = Screen.height/8;

			GUI.Box (new Rect(0,0,Screen.width, Screen.height), "Menu");
			if(GUI.Button (new Rect (x1,y1, xLen, yStep/2), "Return", sty)) {
				paused = false;
				Time.timeScale=1;
			}
			if(GUI.Button (new Rect (x1,y1+yStep, xLen, yStep/2), "New game", sty)) {
				Application.LoadLevel (1);
				Time.timeScale=1;
			}
			if(GUI.Button (new Rect (x1,y1+2*yStep, xLen, yStep/2), "Options", sty)) {

			}
			if(GUI.Button (new Rect (x1,y1+3*yStep, xLen, yStep/2), "Return to main menu", sty)) {
				Application.LoadLevel (0);
				Time.timeScale=1;
			}
		}	
	}
}
