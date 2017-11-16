using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiController : MonoBehaviour {

	public Text pointsText;

	void Start()
	{
		if (pointsText) {
			pointsText.text = "Treasure: 0";
		}
	}

	public void UpdatePoints(int amount){
		if (pointsText) {
			pointsText.text = "Treasure: " + amount;
		}
	}
}
