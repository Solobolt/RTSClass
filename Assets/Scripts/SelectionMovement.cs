using UnityEngine;
using System.Collections;

public class SelectionMovement : MonoBehaviour {

	public GameObject selectedUnit;

	//building placement
	public bool placingBuilding = false;
	public GameObject preBuilding;
    public GameObject finalObject;
    private GameObject currentBox;

    //multiUnitSelection
    private Vector3 clickPos;
    public GameObject selectionBox;
    private bool hasSelected = true;
    private bool boxCreated = false;
    private Ray _Ray;
    private RaycastHit _Hit;

	//mouse clicking 
	public Vector3 mousePosition;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		locateMouse ();
	}

	//locates the mouse pointer in the world
	void locateMouse()
	{
		//Fire ray at world
		_Ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		
		if(Physics.Raycast (_Ray,out _Hit))
		{
			mousePosition = _Hit.point;
		}


        //Draws a box to select units
        if (Input.GetMouseButtonDown(0))
        {
            clickPos = mousePosition;
        }

        //Right Clikc to seleect npc
        if (Input.GetMouseButton (0))
		{
			//if targeted object is tagged as player, make it selected object
			if(_Hit.transform.tag=="Player" && placingBuilding == false)
			{
				selectedUnit = _Hit.transform.gameObject;
			}

			if(_Hit.transform.tag != "Player")
			{
				selectedUnit = null;
			}

            //Drags a box collider to sellect multiple units at once
            if (mousePosition != clickPos)
            {
                CreateSelectionBox();
            }
		}

       

        //decdes what happens when the player lifts thier mouse buttopn
        if(Input.GetMouseButtonUp(0))
        {
            Destroy(currentBox);
            boxCreated = false;
            hasSelected = true;
        }

		//left click, move selected unit to position
		if(Input.GetMouseButton (1) && selectedUnit != null)
		{
			Debug.DrawLine (Camera.main.transform.position,mousePosition,Color.green);
			selectedUnit.GetComponent<PlayerUnit>().Move (mousePosition);

		}
		
	}

    //Creates a pre tower and then places down a tower when clicked
    public void CreateTower(GameObject tower)
    {
        finalObject = tower;
        //placing pre building
        if (placingBuilding == false)
        {
            placingBuilding = true;
            selectedUnit = null;
            GameObject PreTower = Instantiate(preBuilding, mousePosition, _Hit.transform.rotation) as GameObject;

            if (finalObject != null)
            {
                PreTower.GetComponent<Transform>().localScale = finalObject.GetComponent<Transform>().localScale;
                PreTower.GetComponent<PreBuilding>().towerToPlace = finalObject;
            } 
        }
    }

    //Creates a selection box and changes its transform and scale to accompany mouse movement
    //NOTE: Selection box must be trigger
    void CreateSelectionBox()
        {
        hasSelected = false;
        if (hasSelected == false)
        {
            if (boxCreated == false)
            {
                GameObject _SelectionBox = Instantiate(selectionBox, mousePosition, new Quaternion(0, 0, 0, 0)) as GameObject;
                currentBox = _SelectionBox;
                boxCreated = true;
            }

            //scales the box collider depending on how the mouse moved
            float xScale = clickPos.x - mousePosition.x;
            float yScale = clickPos.z - mousePosition.z;

            //moves the box collider to that one corner is at the point of the mouse click and the other is where the mouse currently is                    
            float xPos = (xScale / 2.0f) - clickPos.x;
            float yPos = 2.5f;
            float zPos = (yScale / 2.0f) - clickPos.z;

            //sets the scale and position of thje box collider
            currentBox.GetComponent<Transform>().localScale = new Vector3(xScale, 5, yScale);
            currentBox.GetComponent<Transform>().position = new Vector3(-xPos, yPos, -zPos);
            hasSelected = false;
        }
    }

}
