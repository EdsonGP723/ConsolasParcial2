using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
	public LifeSystem[] lifes;
	public TMP_Text[] lifestxt;
	public int loosers;
	// Update is called every frame, if the MonoBehaviour is enabled.
	private void Update()
	{
		CheckLife();
		if (loosers == 3)
		{
			Time.timeScale = 0f;
		}
	}
	
	private void CheckLife(){
		lifestxt[0].text = lifes[0].life.ToString();
		lifestxt[1].text = lifes[1].life.ToString();
		lifestxt[2].text = lifes[2].life.ToString();
		lifestxt[3].text = lifes[3].life.ToString();
	}
}
