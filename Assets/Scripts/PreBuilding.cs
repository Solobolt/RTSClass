using UnityEngine;
using System.Collections;

public class PreBuilding : MonoBehaviour {
    private GameController gameController;

    Transform myTransform;
    Renderer myRenderer;

	SelectionMovement selection;

	private bool placed = false;
    private bool placeable = true;
    public GameObject towerToPlace;

    public Material canBuildShader;
    public Material noBuildShader;

	// Use this for initialization
	void Start () {
        myTransform = this.transform;
        myRenderer = this.GetComponent<Renderer>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        selection = GameObject.FindGameObjectWithTag ("GameController").GetComponent<SelectionMovement>();
	}
	
	// Update is called once per frame
	void Update () {

		//PreBuilding Follow Curser
		if(selection.placingBuilding == true && placed == false)
		{
            Vector3 towerPos = selection.mousePosition;
            towerPos.y = 0.5f * myTransform.localScale.y;
            myTransform.position = towerPos;
		}

		//prebuilding placements
		if(Input.GetMouseButton (0))
		{
            if (placeable == true)
            {
                selection.placingBuilding = false;
                placed = true;
                Instantiate(towerToPlace, myTransform.position, myTransform.rotation);
                Destroy(this.gameObject);
            }
		}

        ChangeRenderer();
	}

    //checks if the building collides with an object
    void OnTriggerEnter(Collider otherObject)
    {
        if(otherObject.transform.tag == "Tower")
        {
            placeable = false;
        }
    }

    void OnTriggerStay(Collider otherObject)
    {
        if (otherObject.transform.tag == "Tower")
        {
            placeable = false;
        }
    }

    void OnTriggerExit(Collider otherObject)
    {
        placeable = true;
    }

    //Changes the materail depending on weather or not the player can build
    void ChangeRenderer()
    {
        if(placeable == false)
        {
            myRenderer.material = noBuildShader;
        }
        else
        {
            myRenderer.material = canBuildShader;
        }
    }
}
