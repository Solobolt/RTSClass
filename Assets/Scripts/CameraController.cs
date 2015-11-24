using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	//Mouse Scrolling
	private int scrollDistance = 5;
	private float scrollSpeed = 30.0f;

	//Mouse zoom
	public float cameraHeight = 10.0f;
	public GameObject camera;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		moveCamera ();

		cameraZooming();
	}

	//Controls affecting the zoom and placement of the camera
	void cameraZooming(){

		//Move camera focus and height based on raycast from maincamera
		RaycastHit hit;
		Vector3 direction = (transform.position - camera.transform.position).normalized;

		if (Physics.Raycast (camera.transform.position, direction, out hit, 1000.0f)) {

			Debug.DrawLine (camera.transform.position, hit.point);

			//Adjust height of the cameraHeight based on difference from focus point
			if (Vector3.Distance (transform.position, camera.transform.position) 
				!= cameraHeight && hit.transform.tag == "Ground") {
				Vector3 newPos = camera.transform.position;
				newPos.y = hit.point.y + cameraHeight;
				camera.transform.position = newPos;
			}
		}

		//Adjust Camera Height - Scrollwheel
		if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
			cameraHeight -= 1.0f;

			if (cameraHeight < 5.0f)
				cameraHeight = 5.0f;
		} 
		else if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
			cameraHeight += 1.0f;
			
			if (cameraHeight > 30.0f)
				cameraHeight = 30.0f;
		}

	}

	//Move Camera using mouse
	void moveCamera(){
		if (Input.mousePosition.x < scrollDistance) {
			transform.Translate (Vector3.right * -scrollSpeed * Time.deltaTime);
		}

		if (Input.mousePosition.x >= Screen.width - scrollDistance) {
			transform.Translate (Vector3.right * scrollSpeed * Time.deltaTime);
		}

		if (Input.mousePosition.y < scrollDistance) {
			transform.Translate (transform.forward * -scrollSpeed * Time.deltaTime);
		}

		if (Input.mousePosition.y >= Screen.height - scrollDistance) {
			transform.Translate (transform.forward * scrollSpeed * Time.deltaTime);
		}
	}


}
