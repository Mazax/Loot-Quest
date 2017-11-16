using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cargo : MonoBehaviour {

	public int value = 10;

	public Player player;

	void Awake(){
		if (!player) {
			player = FindObjectOfType<Player> ();
		}
	}




	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Sea")
		{
			//Play sound 
			if (player) {
				player.PlayWaterSplashSound ();
			}

			//add points
			player.AddPoints(value);

			//Debug.LogError ("Collision with sea!");
			//Add points
			DestroySelf();
		}
	}

	public void DestroySelf()
	{
		GameObject.Destroy(gameObject);

	}

}
