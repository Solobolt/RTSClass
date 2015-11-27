using UnityEngine;
using System.Collections;

public class SelectionMovement : MonoBehaviour {

	public GameObject selectedUnit;

	//building placement
	public bool placingBuilding = false;
	public GameObject preBuilding;
    public GameObject finalObject;

    //multiUnitSelection
    private Vector3 clickPos;
    public GameObject selectionBox;
    private bool hasSelected = true;

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
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		
		if(Physics.Raycast (ray,out hit))
		{
			mousePosition = hit.point;
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
			if(hit.transform.tag=="Player" && placingBuilding == false)
			{
				selectedUnit = hit.transform.gameObject;
			}

			if(hit.transform.tag != "Player")
			{
				selectedUnit = null;
			}

            if (mousePosition != clickPos)
            {
                print("Mouse Has moved");
                if(!hasSelected)
                {
                    GameObject _SelectionBox = Instantiate(selectionBox, mousePosition, new Quaternion(0, 0, 0, 0)) as GameObject;
                    hasSelected = true;
                }
                
            }
		}

        if(Input.GetMouseButtonUp(0))
        {
            
            hasSelected = false;
        }

		//left click, move selected unit to position
		if(Input.GetMouseButton (1) && selectedUnit != null)
		{
			Debug.DrawLine (Camera.main.transform.position,mousePosition,Color.green);
			selectedUnit.GetComponent<PlayerUnit>().Move (mousePosition);

		}

		//placing pre building
		if(Input.GetKeyDown("f") && placingBuilding == false)
		{
			placingBuilding = true;
			selectedUnit = null;
			GameObject PreTower = Instantiate (preBuilding,mousePosition,hit.transform.rotation) as GameObject;

            if(finalObject != null)
            {
                PreTower.GetComponent<Transform>().localScale = finalObject.GetComponent<Transform>().localScale;
                PreTower.GetComponent<PreBuilding>().towerToPlace = finalObject;
            }
		}
	}


}
