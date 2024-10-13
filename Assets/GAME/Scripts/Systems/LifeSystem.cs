using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystem : MonoBehaviour
{
	public int life = 15;
	public GameObject barrera;
	public GameObject player;
	private GameManager looser;
	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	private void Start()
	{
		looser = FindObjectOfType<GameManager>();
	}
	// Update is called every frame, if the MonoBehaviour is enabled.
	private void Update()
	{
		if (life == 0)
		{
			Loose();
		}
	}
	
	private void Loose(){
		barrera.SetActive(true);
		player.SetActive(false);
	}
	
	// OnTriggerEnter is called when the Collider other enters the trigger.
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Ball"))
		{
			life--;
			if (life == 0)
			{
				looser.loosers += 1;
			}
			var speedball = other.GetComponent<Ball>();
			speedball.speed = 2f;
			BallPool.Instance.Return(other.gameObject);
			SpawnManager newBall = FindObjectOfType<SpawnManager>();
			newBall.InstantiateBall();
		}
	}
}
