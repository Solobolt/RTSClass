using UnityEngine;
using System.Collections;

public class PreBuilding : MonoBehaviour {
    Transform myTransform;

	SelectionMovement selection;

	private bool placed = false;
    public GameObject towerToPlace;

	// Use this for initialization
	void Start () {
        myTransform = this.transform;
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
            Instantiate(towerToPlace,myTransform.position,myTransform.rotation);
            Destroy(this.gameObject);
		}
	}
}
