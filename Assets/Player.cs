using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public double population = 8000000000;
	private double populationGrowth = 1600000000;
	public GameObject endGame;
	public static float survival=0;
	public GameObject bigExplosion;
	public static int portalCount;
	public static int mothershipCount;
	public static int kamikazeCount;

	public static float getSurvival(){
		return survival;
	}

	// Use this for initialization
	void Start () {
		portalCount = 0;
		mothershipCount = 0;
		kamikazeCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		survival+=Time.deltaTime;
		if (!IsInvoking ()) {
			Invoke ("addPopulation", 1);
		}
		if(population<=0){
			population=0;
			Application.LoadLevel (2);
			//Instantiate(endGame,transform.position,transform.rotation);
		}

	}
	void addPopulation(){
		population += (population / populationGrowth) * 0.1 * (double) Random.Range(5, 20);
	}
	void OnCollisionEnter2D(Collision2D collision){
		population-=  Random.Range(50000000, 100000000);

	}
	void OnGUI(){
		GUI.Label (new Rect (Screen.width/2-100,10, 200, 50), ("Population: "+(long)population).ToString());

	}
}
