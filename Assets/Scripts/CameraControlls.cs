using UnityEngine;
using System.Collections;

public class CameraControlls : MonoBehaviour {

	private Transform myTransform;
	private Vector3 currentPos;

    //holds camera mode variables
    public Camera playerCamera;
    private bool inBirdsEye = false;
    //Holds the size of the orthonographic views
    private float othroSize = 20;

    //Handles camera movement variables
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
        if (inBirdsEye == false)
        {
            scrollZoom();
            mouseMovent();
            LockBoarders();
        }
        else
        {

        }
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

    //Sets the camera to orthnonographic view
    public void toggleBirdsEye()
    {
        if(inBirdsEye == true)
        {
            inBirdsEye = false;
        }
        else
        {
            inBirdsEye = true;
        }
        setCameraTrans();
    }

    //sets the cameras tranform
    void setCameraTrans()
    {
        if(inBirdsEye == true)
        {
            //Sets the camera position (rotation should always be 0)
            myTransform.position = new Vector3(0, 10, 0);
            myTransform.rotation = Quaternion.Euler(0,0,0);

            //sets camera rotation (Position should always be 0)
            playerCamera.transform.rotation = Quaternion.Euler(90, 0, 0);
            playerCamera.orthographic = true;
            playerCamera.orthographicSize = othroSize;
        }
        else
        {
            myTransform.position = new Vector3(0, 15, 0);
            myTransform.rotation = Quaternion.Euler(0, 0, 0);

            playerCamera.transform.rotation = Quaternion.Euler(65, 0, 0);
            playerCamera.orthographic = false;
        }
        
    }
}
