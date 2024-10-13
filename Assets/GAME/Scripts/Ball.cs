using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	public float speed;
	private Rigidbody rb;
	private Vector3 direction;
    // Start is called before the first frame update
	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		Launch();
    }

	private void Launch(){
		float x = Random.Range(1,2) == 0 ? -1 : 1;
		float z = Random.Range(1,2) == 0 ? -1 : 1;
		rb.velocity = new Vector3 (x*speed,0,z*speed);
	}
	
	// OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider.
	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.CompareTag("Contact") || collision.gameObject.CompareTag("Player"))
		{
			float x = Random.Range(0,2) == 0 ? -1 : 1;
			float z = Random.Range(0,2) == 0 ? -1 : 1;
			speed += 0.2f;
			rb.velocity = new Vector3 (x*speed,0,z*speed);
		}
	}
}