using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	private bool paused = true;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnGUI() {
		if(paused) {
			int x1 = Screen.width/2 - Screen.width/8;
			int xLen = Screen.width/4;
			int y1 = Screen.height/2 - Screen.width/8;
			int yStep = Screen.height/8;
			
			//GUI.Box (new Rect(0,0,Screen.width, Screen.height), "Menu");
			if(GUI.Button (new Rect (x1,y1, xLen, yStep/2), "New game")) {
				Application.LoadLevel (1);
			}
			if(GUI.Button (new Rect (x1,y1+yStep, xLen, yStep/2), "Options")) {
				
			}
			if(GUI.Button (new Rect (x1,y1+2*yStep, xLen, yStep/2), "Credits")) {
				
			}
			if(GUI.Button (new Rect (x1,y1+3*yStep, xLen, yStep/2), "Exit game")) {
				Application.Quit ();
			}
		}	
	}
}
