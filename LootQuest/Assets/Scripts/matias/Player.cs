using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public GuiController guiController;

	public AudioSource waterSplashSound;

	public int points = 0;

	void Start()
	{
		points = 0;
		UpdateGui (points);
	}

	public void AddPoints(int amount){
		points += amount;
		UpdateGui (points);
	}

	public void UpdateGui(int points){
		guiController.UpdatePoints (points);
	}

	public void PlayWaterSplashSound(){
		waterSplashSound.Play ();
	}	
}
