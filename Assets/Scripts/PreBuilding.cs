using UnityEngine;
using System.Collections;

public class PreBuilding : MonoBehaviour {

	SelectionMovement selection;

	private bool placed = false;

	// Use this for initialization
	void Start () {
		selection = GameObject.FindGameObjectWithTag ("GameController").GetComponent<SelectionMovement>();
	}
	
	// Update is called once per frame
	void Update () {

		//PreBuilding Follow Curser
		if(selection.placingBuilding == true && placed == false)
		{
			transform.position = selection.mousePosition;
		}

		//prebuilding placements
		if(Input.GetMouseButton (0))
		{
			selection.placingBuilding = false;
			placed = true;
		}
	}
}
