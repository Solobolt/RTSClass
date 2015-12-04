using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    private int damage = 1;
    private Transform myTransform;

    private float moveSpeed = 20;
    private Vector3 startPos;
    private Vector3 currentPos;
    private float range = 10.0f;

	// Use this for initialization
	void Start () {
        myTransform = this.transform;
        startPos = myTransform.position;
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    //makes the object move forward
    void Move()
    {
        myTransform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        currentPos = myTransform.position;

        if(Vector3.Distance(startPos,currentPos) > range)
        {
            Destroy(this.gameObject);
        }
    }

    //Changes the range of the projectile in the script
    public void editRange(float newRange)
    {
        range = newRange;
    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.tag == "Enemy")
        {
            coll.gameObject.GetComponent<Enemy>().RemoveHealth(damage);
            Destroy(this.gameObject);
        }
    }
}
