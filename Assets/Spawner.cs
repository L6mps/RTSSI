using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public GameObject cannon;
	public GameObject slot;
	GameObject[] slots =new GameObject[10];
	GameObject[] cannons= new GameObject[10];
	int cannonCount=0;
	public static string controlledCannon;
	public static string getControlledCannon(){
				return controlledCannon;
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
          angle+=36;
          newPosition.x=384*Mathf.Cos (angle*Mathf.Deg2Rad);
          newPosition.y=384*Mathf.Sin ((angle)*Mathf.Deg2Rad);
			tran.Rotate (0,0,36);
  		}
		tran.Rotate (0,0,90);

	
	}
	
	// Update is called once per frame
	void Update () {
				if (Input.GetMouseButtonDown (1)) {
						Vector3 newPosition = Vector3.zero;
						Vector3 mouse = Input.mousePosition;
						mouse.z = 1000;
						newPosition = Camera.mainCamera.ScreenToWorldPoint (mouse);
						newPosition.z = 0;
						for (int i=0; i<10; i++) {
								if (Mathf.Abs (newPosition.x - slots [i].transform.position.x) < 50 &&
				    			Mathf.Abs (newPosition.y - slots [i].transform.position.y) < 50) {
										int isThereACannon = 0;
										for (int j=0; j<cannonCount; j++) {
						Debug.Log (cannons [j].transform.position.x - newPosition.x);
												if (Mathf.Abs (cannons [j].transform.position.x - newPosition.x) < 50 &&
						    						Mathf.Abs (cannons [j].transform.position.y-newPosition.y) < 50) {
														isThereACannon = 1;
														break;
												}
										}
										if (isThereACannon == 0) {
												cannons [cannonCount] = (GameObject)Instantiate
												(cannon, slots[i].transform.position, slots[i].transform.rotation);
												cannons [cannonCount].transform.position = slots [i].transform.position;
												cannons [cannonCount].transform.rotation = slots[i].transform.rotation;
												cannons [cannonCount].name = cannons [cannonCount].name + cannonCount;
												cannonCount++;
										} else {
												for (int j=0; j<cannonCount; j++) {
														if (Mathf.Abs (cannons [j].transform.position.x - newPosition.x) < 50 &&
																Mathf.Abs (cannons [j].transform.position.y - newPosition.y) < 50) {
																controlledCannon = cannons [j].name;
																break;
														}
												}
										}
								}
						}
				}
	
	}
}
