using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {
	
	private bool zoomed;
	private bool moving;
	private Vector3 movingTowards;
	private float movingStep;
	private Quaternion cameraAngle = Quaternion.identity;
	private float rotatingStep;
	private Vector3 cameraStartPos;
	public float cameraZoomedDist = 600f;
	public float moveSteps = 15f;
	public float outerZoom = 2000f;
	public float innerZoom = 300f;
	private float zoomDifference;
	private int currentSteps = 0;
	private int screenSizeMin = Screen.width/8;
	private int screenSizeMax;
	private float angle;
	public GameObject cross;
	private GameObject cross2;
	
	
	void Start () {
		zoomed = false;  
		moving = false;
		cameraStartPos = transform.position;
		zoomDifference = outerZoom - innerZoom;
		screenSizeMax = 7*screenSizeMin;
		cross2=(GameObject)Instantiate (cross,new Vector3(0,0,900),transform.rotation);

	}
	
	// Update is called once per frame
	void Update () {
		if(!moving) {
			if(Input.GetKeyUp("1")) {
				moveToSelectedCannon (0);
			}
			if(Input.GetKeyUp("2")) {
				moveToSelectedCannon (1);
			}
			if(Input.GetKeyUp("3")) {
				moveToSelectedCannon (2);
			}
			if(Input.GetKeyUp("4")) {
				moveToSelectedCannon (3);
			}
			if(Input.GetKeyUp("5")) {
				moveToSelectedCannon (4);
			}
			if(Input.GetKeyUp("6")) {
				moveToSelectedCannon (5);
			}
			if(Input.GetKeyUp("7")) {
				moveToSelectedCannon (6);
			}
			if(Input.GetKeyUp("8")) {
				moveToSelectedCannon (7);
			}
			if(Input.GetKeyUp("9")) {
				moveToSelectedCannon (8);
			}
			if(Input.GetKeyUp("0")) {
				moveToSelectedCannon (9);
			}
			if(Input.GetMouseButtonUp(1)) {
				if(Input.mousePosition.x > screenSizeMin && Input.mousePosition.x < screenSizeMax) {
					if(zoomed) {
						moving = true;
						zoomed = false;
						movingTowards = cameraStartPos;
						cameraAngle = Quaternion.identity;
						currentSteps = 0;
						angle = 0;
					}
					else {
						zoomed = true;
						Vector3 mousePos1 = Input.mousePosition;
						Vector3 mousePos = camera.ScreenToWorldPoint(mousePos1);
						moveCamera (mousePos);
						rotateCamera (mousePos);
						moving = true;
						currentSteps = 0;
					}
				}
			}
		}
		if(moving) {
			currentSteps++;
			if(zoomed) {
				if(camera.orthographicSize>innerZoom)
					camera.orthographicSize = camera.orthographicSize - (zoomDifference/moveSteps);
				else
					camera.orthographicSize = innerZoom;
			}
			else {
				if(camera.orthographicSize< outerZoom)
					camera.orthographicSize = camera.orthographicSize + (zoomDifference/moveSteps);
				else
					camera.orthographicSize = outerZoom;
			}
			transform.position = Vector3.MoveTowards(transform.position, movingTowards, movingStep);
			transform.rotation = Quaternion.RotateTowards(transform.rotation, cameraAngle, rotatingStep);
			cross2.transform.rotation=transform.rotation;
			if(currentSteps == moveSteps) {
				moving = false;
			}
		}
	}
	
	void moveCamera(Vector3 pos) {
		float dist = Mathf.Sqrt(pos.x*pos.x + pos.y*pos.y);
		float sinAlpha = pos.y / dist;
		try {
						if (pos.x > 0) {
								pos.y = sinAlpha * cameraZoomedDist;
								pos.x = Mathf.Sqrt (cameraZoomedDist * cameraZoomedDist - pos.y * pos.y);
						} else {
								pos.y = sinAlpha * cameraZoomedDist;
								pos.x = -Mathf.Sqrt (cameraZoomedDist * cameraZoomedDist - pos.y * pos.y);
						}
		} catch (System.Exception ex) {
			pos.x = 0;
			if(pos.y>0)
				pos.y = cameraZoomedDist;
			else
				pos.y = -cameraZoomedDist;
		}
		movingTowards = pos;
		float dist2 = Mathf.Sqrt((pos.x-transform.position.x)*(pos.x-transform.position.x) + (pos.y-transform.position.y)*(pos.y-transform.position.y));
		movingStep = dist2 / moveSteps;
	}
	void rotateCamera(Vector3 pos) {
		float prevAngle = angle;
		angle = 0;
		float sinAlpha = pos.y / Mathf.Sqrt (pos.x*pos.x + pos.y*pos.y);
		if(pos.x<0) {
			if(pos.y>0)
				angle = Mathf.PI/2 - Mathf.Asin (sinAlpha);
			else
				angle = Mathf.Asin (-sinAlpha)+Mathf.PI/2;
		}
		else {
			if(pos.y>0)
				angle = - Mathf.PI/2 + Mathf.Asin (sinAlpha);
			else
				angle = Mathf.Asin (sinAlpha) - (Mathf.PI/2);
		}
		cameraAngle = Quaternion.AngleAxis(angle*Mathf.Rad2Deg, Vector3.forward);
		float angleDiff = Mathf.Abs(Mathf.Rad2Deg*angle-Mathf.Rad2Deg*prevAngle);
		if(angleDiff > 180)
			angleDiff = 360-angleDiff;
		rotatingStep = angleDiff / moveSteps;
	}

	public void moveToSelectedCannon(int slot) {
		Vector3 newPos = Spawner.getSlotPos(slot);
		newPos.z = -1000;
		moveCamera (newPos);
		rotateCamera (newPos);
		moving = true;
		currentSteps = 0;
		if(!zoomed)
			zoomed=true;
	}
}
