using UnityEngine;
using System.Collections;

public class CannonControl : MonoBehaviour {
	public float speed=100;
	public float angle=Mathf.PI/2F;
	public float radius=0.1F;
	public GameObject projectile;
	public float mouseAngle=0;
	private float maxAngle;
	private float minAngle;
	private float objectAngle;
	private Quaternion startingRotation;
	
	// Use this for initialization
	void Start () {
		startingRotation = transform.rotation;
		float radius=Mathf.Sqrt (Mathf.Pow (transform.position.x,2)+Mathf.Pow (transform.position.y,2));
		if(transform.position.y<0){
			objectAngle=-(Mathf.Asin((transform.position.x)/radius)+Mathf.PI);
		}
		else if(transform.position.y>=0){
			objectAngle=Mathf.Asin((transform.position.x)/radius);
		}
		objectAngle=Mathf.Rad2Deg*objectAngle;
		maxAngle=objectAngle+75;
		minAngle=objectAngle-75;
		angle = objectAngle;
	}
	
	// Update is called once per frame
	void Update () {
		if(Spawner.getControlledCannon()==transform.parent.name){
			Vector3 objectPos=transform.position;
			Vector3 mouse= Input.mousePosition;    
			mouse.z=0;
			Vector3 mousePos=Camera.main.ScreenToWorldPoint (mouse);
			float mouseRadius=Mathf.Sqrt (Mathf.Pow (mousePos.x-objectPos.x,2)+Mathf.Pow (mousePos.y-objectPos.y,2));
			if(mouseRadius!=0 && mousePos.y-objectPos.y<0){
				mouseAngle=-(Mathf.Asin((mousePos.x-objectPos.x)/mouseRadius)+Mathf.PI);
			}
			else if(mouseRadius!=0 && mousePos.y-objectPos.y>=0){
				mouseAngle=Mathf.Asin((mousePos.x-objectPos.x)/mouseRadius);
			}
			mouseAngle=Mathf.Rad2Deg*mouseAngle;
			if(maxAngle>90){
				if (mouseAngle < maxAngle-360 && mouseAngle+360> minAngle || mouseAngle < maxAngle && mouseAngle> minAngle) {
					transform.Rotate (0, 0, angle - mouseAngle);
					angle = mouseAngle;
				}
			}
			else if(minAngle<-270){
				if(mouseAngle-360<maxAngle && mouseAngle>minAngle+360 || mouseAngle<maxAngle && mouseAngle>minAngle){
					transform.Rotate(0,0,angle-mouseAngle);
					angle=mouseAngle;
				}
			}
			else if(mouseAngle<maxAngle && mouseAngle>minAngle){
				transform.Rotate(0,0,angle-mouseAngle);
				angle=mouseAngle;
			}
			if(angle>=360)
				angle-=360;
			if(angle<=-360)
				angle+=360;
			if(Input.GetButtonDown ("Fire1")){
				Instantiate(projectile,transform.position,transform.rotation);
			}
		}
		else if(angle!=objectAngle){
			transform.rotation = startingRotation;
			angle = objectAngle;
		}
		
	}
}