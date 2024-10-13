using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	public GameObject ballPrefab;
	public Transform[] spawnTransforms;
	
	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	protected void Start()
	{
		StartCoroutine(SpawnBall());
	}
	
	
	private IEnumerator SpawnBall(){
		while(true){
			InstantiateBall();
			yield return new WaitForSeconds(10f);
		}
	}
	
	
	
	public void InstantiateBall(){
		Transform spawnDirection = spawnTransforms[Random.Range(0,spawnTransforms.Length)];
		BallPool.Instance.Get().transform.position = spawnDirection.position;
	}
}
