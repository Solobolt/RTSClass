using UnityEngine;
using System.Collections;

public class CameraControlls : MonoBehaviour {

	private Transform myTransform;
	private Vector3 currentPos;

	private float moveSpeed = 25.0f;
	private float dragSpeed = 100.0f;
	public float maxZoom = 200.0f;
	public float minZoom = 20.0f;
	private float scrollSpeed = 1000.0f;

    private float boarderLimits = 15;

	// Use this for initialization
	void Start () {
		myTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		scrollZoom ();
		mouseMovent ();
        LockBoarders();
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


    //Stops the camera from being able to travel too far away from the game scene
    void LockBoarders()
    {
        Vector3 currentPos = myTransform.position;
        if(currentPos.x > boarderLimits)
        {
            currentPos.x = boarderLimits;
        }

        if (currentPos.x < -boarderLimits)
        {
            currentPos.x = -boarderLimits;
        }

        if (currentPos.z > boarderLimits - 5)
        {
            currentPos.z = boarderLimits - 5;
        }

        if (currentPos.z < -boarderLimits - 5)
        {
            currentPos.z = -boarderLimits - 5;
        }

        myTransform.position = currentPos;
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
