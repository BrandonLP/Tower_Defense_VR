using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTracker : MonoBehaviour {
	public int currentPoints;

	// Use this for initialization
	void Start () {
		currentPoints = 0;
	}
		
	//this function is called to add points when an enemy is killed
	public void AddPoints(int pointsToAdd) {
		currentPoints += pointsToAdd;
	}

	//subtract the amt that an item costs from points
	public void BuyItem(int price) {
		currentPoints -= price;
	}
}
