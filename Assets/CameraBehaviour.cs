using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

	private bool zoomed;


	void Start () {
		zoomed = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp("z")) {
			if(zoomed) {
				camera.orthographicSize = 3000;
				zoomed = false;
			}
			else {
				camera.orthographicSize = 300;
				zoomed = true;
				Vector3 zoomPos = camera.ViewportToWorldPoint(camera.ScreenToViewportPoint(Input.mousePosition));
				transform.position = zoomPos;
			}
		}
	}
}
