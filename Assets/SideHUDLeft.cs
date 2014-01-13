using UnityEngine;
using System.Collections;

public class SideHUDLeft : MonoBehaviour {

	public GUIStyle sty;
	//private Camera cam = this;

	void OnGUI() {
		int boxWidth = Screen.width/16;
		int boxHeight = Screen.height/32;
		GUI.Box (new Rect(0,0*boxHeight,2*boxWidth, boxHeight), "Sectors", sty);
		if(GUI.Button (new Rect(0,1*boxHeight,boxWidth, boxHeight), "Alpha",sty )) {
			GetComponent<CameraBehaviour>().moveToSelectedCannon(0);
		}
		if(GUI.Button (new Rect(0,2*boxHeight,boxWidth, boxHeight), "Bravo", sty)) {
			GetComponent<CameraBehaviour>().moveToSelectedCannon(1);
		}
		GUI.Box (new Rect(0+boxWidth,1*boxHeight,boxWidth, boxHeight), "0", sty);
		GUI.Box (new Rect(0+boxWidth,2*boxHeight,boxWidth, boxHeight), "0", sty);
		if(GUI.Button (new Rect(0,3*boxHeight,boxWidth, boxHeight), "Charlie", sty)) {
			GetComponent<CameraBehaviour>().moveToSelectedCannon(2);
		}
		if(GUI.Button (new Rect(0,4*boxHeight,boxWidth, boxHeight), "Delta", sty)) {
			GetComponent<CameraBehaviour>().moveToSelectedCannon(3);
		}
		GUI.Box (new Rect(0+boxWidth,3*boxHeight,boxWidth, boxHeight), "0", sty);
		GUI.Box (new Rect(0+boxWidth,4*boxHeight,boxWidth, boxHeight), "0", sty);
		if(GUI.Button (new Rect(0,5*boxHeight,boxWidth, boxHeight), "Echo", sty)) {
			GetComponent<CameraBehaviour>().moveToSelectedCannon(4);
		}
		if(GUI.Button (new Rect(0,6*boxHeight,boxWidth, boxHeight), "Foxtrot", sty)) {
			GetComponent<CameraBehaviour>().moveToSelectedCannon(5);
		}
		GUI.Box (new Rect(0+boxWidth,5*boxHeight,boxWidth, boxHeight), "0", sty);
		GUI.Box (new Rect(0+boxWidth,6*boxHeight,boxWidth, boxHeight), "0", sty);
		if(GUI.Button (new Rect(0,7*boxHeight,boxWidth, boxHeight), "Golf", sty)) {
			GetComponent<CameraBehaviour>().moveToSelectedCannon(6);
		}
		if(GUI.Button (new Rect(0,8*boxHeight,boxWidth, boxHeight), "Hotel", sty)) {
			GetComponent<CameraBehaviour>().moveToSelectedCannon(7);
		}
		GUI.Box (new Rect(0+boxWidth,7*boxHeight,boxWidth, boxHeight), "0", sty);
		GUI.Box (new Rect(0+boxWidth,8*boxHeight,boxWidth, boxHeight), "0", sty);
		if(GUI.Button (new Rect(0,9*boxHeight,boxWidth, boxHeight), "India", sty)) {
			GetComponent<CameraBehaviour>().moveToSelectedCannon(8);
		}
		if(GUI.Button (new Rect(0,10*boxHeight,boxWidth, boxHeight), "Juliet", sty)) {
			GetComponent<CameraBehaviour>().moveToSelectedCannon(9);
		}
		GUI.Box (new Rect(0+boxWidth,9*boxHeight,boxWidth, boxHeight), "0", sty);
		GUI.Box (new Rect(0+boxWidth,10*boxHeight,boxWidth, boxHeight), "0", sty);
		GUI.Box (new Rect(0,21*boxHeight,boxWidth*2, boxHeight), "Enemies", sty);
		GUI.Box (new Rect(0,22*boxHeight,boxWidth, boxHeight), "Portals", sty);
		GUI.Box (new Rect(0+boxWidth,22*boxHeight,boxWidth, boxHeight), Player.portalCount.ToString(), sty);
		GUI.Box (new Rect(0,23*boxHeight,boxWidth, boxHeight), "Motherships", sty);
		GUI.Box (new Rect(0+boxWidth,23*boxHeight,boxWidth, boxHeight), Player.mothershipCount.ToString(), sty);
		GUI.Box (new Rect(0,24*boxHeight,boxWidth, boxHeight), "Kamikazes", sty);
		GUI.Box (new Rect(0+boxWidth,24*boxHeight,boxWidth, boxHeight), Player.kamikazeCount.ToString(), sty);
		GUI.Box (new Rect(0,28*boxHeight,boxWidth, boxHeight), "Research", sty);
		GUI.Box (new Rect(0,29*boxHeight,boxWidth, boxHeight), "R1", sty);
		GUI.Box (new Rect(0,30*boxHeight,boxWidth, boxHeight), "R2", sty);
		GUI.Box (new Rect(0,31*boxHeight,boxWidth, boxHeight), "R3", sty);

	}
}
