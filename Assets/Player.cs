using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public double population = 8000000000;
	private double populationGrowth = 1600000000;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!IsInvoking ()) {
			Invoke ("addPopulation", 1);
		}

	}
	void addPopulation(){
		population += (population / populationGrowth) * 0.1 * (double) Random.Range(5, 20);
	}
	void OnCollisionEnter2D(Collision2D collision){
		population-=  Random.Range(50000000, 100000000);

	}
	void OnGUI(){
		GUI.Label (new Rect (Screen.height, 10, Screen.width-Screen.height, 50), ((long)population).ToString());
	}
}
