using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public long population = 8000000000;
	private float populationGrowth = 1/1600000000;


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
		population += (long)(population * populationGrowth* Random.Range(1/2, 2));
	}
	void onCollisionEnter2D(Collision collision){
		population-=Random.Range(50000000, 100000000);

	}
	void OnGUI(){


		GUI.Label (new Rect (Screen.height, 0, Screen.width-Screen.height, 10), population.ToString ());

	}
}
