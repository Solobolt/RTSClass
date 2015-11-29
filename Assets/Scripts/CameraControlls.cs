using UnityEngine;
using System.Collections;

public class CameraControlls : MonoBehaviour {

	private Transform myTransform;
	private Vector3 currentPos;

	private float moveSpeed = 25.0f;
	private float dragSpeed = 100.0f;
	private float maxZoom = 200.0f;
	private float minZoom = 20.0f;
	private float scrollSpeed = 1000.0f;

	// Use this for initialization
	void Start () {
		myTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		scrollZoom ();
		mouseMovent ();
	}

	//handles camera edge movement
	void mouseEdge()
	{
		if(Input.mousePosition.x >= Screen.width  - 25)
		{
			myTransform.position += Vector3.right * moveSpeed * Time.deltaTime;
		}
		if(Input.mousePosition.x <= 25)
		{
			myTransform.position += Vector3.left * moveSpeed * Time.deltaTime;
		}
		if(Input.mousePosition.y >= Screen.height - 25)
		{
			myTransform.position += Vector3.forward * moveSpeed * Time.deltaTime;
		}
		if(Input.mousePosition.y <= 25)
		{
			myTransform.position += Vector3.back * moveSpeed * Time.deltaTime;
		}
	}

	//hold move
	void mouseMovent()
	{
		if (Input.GetMouseButton (2)) {
			myTransform.position += Vector3.right * Input.GetAxis ("Mouse X") * -dragSpeed * Time.deltaTime;
			myTransform.position += Vector3.forward * Input.GetAxis ("Mouse Y") * -dragSpeed * Time.deltaTime;
		} else {
			mouseEdge();
		}
	}

	//scroll wheel zoom
	void scrollZoom()
	{
		if(Input.GetAxis ("Mouse ScrollWheel") != 0)
		{
			currentPos = myTransform.position;
			currentPos +=Input.GetAxis ("Mouse ScrollWheel") * Vector3.down * scrollSpeed * Time.deltaTime;

			if(currentPos.y > maxZoom)
			{
				currentPos.y = maxZoom;
			}

			if(currentPos.y < minZoom)
			{
				currentPos.y = minZoom;
			}

			myTransform.position = currentPos;
		}
	}
}
