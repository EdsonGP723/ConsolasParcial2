using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{

	public GameObject[] balls; 
	public float moveSpeed = 8f;
	public bool moveInX = true; 
	public float randomMoveRange = 5f; 
	private float limit = 3f;

	private Vector3 targetPosition;

	private float fixedPosition; 
	
	void Start()
	{
		fixedPosition = moveInX ? transform.position.z : transform.position.x;

		targetPosition = transform.position;
	}
	
	void Update()
	{
		balls = GameObject.FindGameObjectsWithTag("Ball");
		
			MoveTowardsClosestBall();
			ClampPositionWithinLimits();
		
	}

	void MoveTowardsClosestBall()
	{
		if (balls.Length > 0)
		{
			GameObject closestBall = GetClosestBall();
			targetPosition = closestBall.transform.position;
			MoveTowardsTarget(targetPosition);
		}
	}

	GameObject GetClosestBall()
	{
		GameObject closestBall = null;
		float closestDistance = Mathf.Infinity;
		foreach (GameObject ball in balls)
		{
			float distance = Vector3.Distance(transform.position, ball.transform.position);
			if (distance < closestDistance)
			{
				closestBall = ball;
				closestDistance = distance;
			}
		}
		return closestBall;
	}

	void MoveTowardsTarget(Vector3 target)
	{
		Vector3 direction = target - transform.position;
		direction.y = 0; // Ignorar la altura
		direction.Normalize();
		transform.position += direction * moveSpeed * Time.deltaTime;
	}

	Vector3 GetRandomTargetPosition()
	{
		float randomX = Random.Range(-randomMoveRange, randomMoveRange);
		float randomZ = Random.Range(-randomMoveRange, randomMoveRange);
		return moveInX ? new Vector3(Mathf.Clamp(transform.position.x + randomX, -limit, limit), transform.position.y, fixedPosition) : new Vector3(fixedPosition, transform.position.y, Mathf.Clamp(transform.position.z + randomZ, -limit, limit));
	}

	

	void ClampPositionWithinLimits()
	{
		float clampedX = Mathf.Clamp(transform.position.x, -limit, limit);
		float clampedZ = Mathf.Clamp(transform.position.z, -limit, limit);
		transform.position = moveInX ? new Vector3(clampedX, transform.position.y, fixedPosition) : new Vector3(fixedPosition, transform.position.y, clampedZ);
	}
	
}
