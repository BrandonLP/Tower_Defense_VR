using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTracker : MonoBehaviour {
	public int currentPoints;
    public TextMesh textObj;

	// Use this for initialization
	void Start () {
		currentPoints = 10;
        textObj = GameObject.Find("PointDisplay").GetComponent<TextMesh>();
        textObj.text = currentPoints.ToString();
	}
		
	//this function is called to add points when an enemy is killed
	public void AddPoints(int pointsToAdd) {
		currentPoints += pointsToAdd; 
        textObj.text = currentPoints.ToString();
	}

	//subtract the amt that an item costs from points
	public void BuyItem(int price) {
		currentPoints -= price;
        textObj.text = currentPoints.ToString();
	}
}
