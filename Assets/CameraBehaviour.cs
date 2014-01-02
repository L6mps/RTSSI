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
	
	
	void Start () {
		zoomed = false;  
		moving = false;
		cameraStartPos = transform.position;
		zoomDifference = outerZoom - innerZoom;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonUp(1)) {
			if(zoomed) {
				moving = true;
				zoomed = false;
				movingTowards = cameraStartPos;
				cameraAngle = Quaternion.identity;
				currentSteps = 0;
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
		if(moving) {
			currentSteps++;
			if(zoomed) {
				if(camera.orthographicSize>innerZoom)
					camera.orthographicSize = camera.orthographicSize - (zoomDifference/moveSteps);
				else
					camera.orthographicSize = innerZoom;
			}
			else {
				if(camera.orthographicSize!= outerZoom)
					camera.orthographicSize = camera.orthographicSize + (zoomDifference/moveSteps);
				else
					camera.orthographicSize = outerZoom;
			}
			transform.position = Vector3.MoveTowards(transform.position, movingTowards, movingStep);
			transform.rotation = Quaternion.RotateTowards(transform.rotation, cameraAngle, rotatingStep);
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
			movingTowards.x = 0;
			if(pos.y>0)
				movingTowards.y = cameraZoomedDist;
			else
				movingTowards.y = -cameraZoomedDist;
		}
		movingTowards = pos;
		movingStep = cameraZoomedDist / moveSteps;
	}
	void rotateCamera(Vector3 pos) {
		float angle = 0;
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
		Debug.Log(angle);
		cameraAngle = Quaternion.AngleAxis(angle*Mathf.Rad2Deg, Vector3.forward);
		rotatingStep = Mathf.Abs((Mathf.Rad2Deg*angle) / moveSteps);
	}
}
