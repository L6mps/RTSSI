﻿using UnityEngine;
using System.Collections;

public class CannonControl : MonoBehaviour {
	public float speed=100;
	public float angle=Mathf.PI/2F;
	public float radius=0.1F;
	public GameObject projectile;
	public static float angle2=0;
	public float mouseAngle=0;


	public static float getAngle(){
				return angle2;
		}
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Spawner.getControlledCannon()==name){
			Vector3 newPosition=transform.position;
			Vector3 mouse= Input.mousePosition;	
			mouse.z=0;
			Vector3 oobject=Camera.main.WorldToScreenPoint (transform.position);
			float mouseRadius=Mathf.Sqrt (Mathf.Pow (mouse.x-oobject.x,2)+Mathf.Pow (mouse.y-oobject.y,2));
			if(mouseRadius!=0 && mouse.y-oobject.y<0){
				mouseAngle=-(Mathf.Asin((mouse.x-oobject.x)/mouseRadius)+Mathf.PI);
			}
			else if(mouseRadius!=0 && mouse.y-oobject.y>=0){
				mouseAngle=Mathf.Asin((mouse.x-oobject.x)/mouseRadius);
			}
			mouseAngle=Mathf.Rad2Deg*mouseAngle;
			transform.Rotate(0,0,angle-mouseAngle);
			angle=mouseAngle;
			if(angle>=360){
				angle-=360;
			}
			if(angle<=-360){
				angle+=360;
			}
			angle2=angle*Mathf.Deg2Rad;
			if(Input.GetButtonDown ("Fire1")){
				Instantiate(projectile,transform.position,transform.rotation);
			}
		}
		else if(angle!=0){
				transform.Rotate(0,0,angle);
				angle=0;
		}
	
	}
}
