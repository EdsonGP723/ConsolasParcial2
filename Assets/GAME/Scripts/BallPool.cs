using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPool : MonoBehaviour
{
	public static BallPool Instance{get; private set;}
	public GameObject ball;
	public int initialAmount = 20;
	
	public List<GameObject> pool = new List<GameObject>(); 
	
	public void Awake(){
		Instance = this;
		FillPool();
	}
	
	
	void FillPool(){
		for (int i = 0; i < initialAmount; i++) {
			GameObject go = Instantiate(ball);
			go.SetActive(false);
			pool.Add(go);
		}
	}
	
	public GameObject Get(){
		
		GameObject ret;	
		if (pool.Count>0)
		{
			ret = pool[pool.Count-1];
			pool.RemoveAt(pool.Count-1);
		}
		else{
			ret = Instantiate(ball);
		}
		ret.SetActive(true);
		return ret;
	}
	
	public void Return(GameObject go){
		go.SetActive(false);
		pool.Add(go);
	}
	
	
	
}
