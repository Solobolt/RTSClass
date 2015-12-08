using UnityEngine;
using System.Collections;

public class TowerDesc : MonoBehaviour {

	public GameObject towerDescription;
	private GameObject currentPanel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ShowDesc()
	{
		currentPanel = Instantiate (towerDescription) as GameObject;
	}
}
