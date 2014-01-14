using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public GameObject cannon;
	public GameObject slot;
	static GameObject[] slots =new GameObject[10];
	GameObject[] cannons= new GameObject[10];
	int cannonCount=0;
	public static string controlledCannon;
	public static string getControlledCannon(){
				return controlledCannon;
		}

	public static Vector3 getSlotPos(int slot) {
		return slots[slot].transform.position;
	}

	// Use this for initialization
	void Start () {
		Vector3 newPosition = Vector3.zero;
		newPosition.y = 0;
		newPosition.x = 384;
		float angle = 0;
		Transform tran =transform;
		tran.Rotate (0,0,-90);
		for(int i=0;i<10;i++){
			slots[i]=(GameObject)Instantiate (slot,newPosition,tran.rotation);
          slots[i].transform.position=newPosition;
          slots[i].transform.rotation=tran.rotation;
          angle-=36;
          newPosition.x=384*Mathf.Cos (angle*Mathf.Deg2Rad);
          newPosition.y=384*Mathf.Sin ((angle)*Mathf.Deg2Rad);
			tran.Rotate (0,0,-36);
  		}
		tran.Rotate (0,0,90);

	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp (0) && Input.GetKey ("left ctrl")) {
			Vector3 newPosition = Vector3.zero;
			Vector3 mouse = Input.mousePosition;
			mouse.z = 1000;
			newPosition = Camera.main.ScreenToWorldPoint (mouse);
			newPosition.z = 0;
			for (int i=0; i<10; i++) {
				if (Mathf.Abs (newPosition.x - slots [i].transform.position.x) < 50 &&
				    Mathf.Abs (newPosition.y - slots [i].transform.position.y) < 50) {
					if(cannons[i]!=null){
						controlledCannon = cannons [i].name;
					}
					else{
						cannons [i] = (GameObject)Instantiate
							(cannon, slots[i].transform.position, slots[i].transform.rotation);
						cannons [i].name = cannons [i].name + i;
					}
					
				}
			}
		}
		
	}
}
