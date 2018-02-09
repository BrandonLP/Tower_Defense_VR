using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {
	//Movement of AI created using tutorial from AI and Games Channel on Youtube
	//"Nav Mesh Basics: Unity Pathfinding Part 1"
	//https://www.youtube.com/watch?v=rKGq42FMV8c

	[SerializeField]
	Transform _towerLocation;
	NavMeshAgent _navMeshAgent;

	// Use this for initialization
	void Start () {
		_navMeshAgent = this.GetComponent<NavMeshAgent> ();
		if(_navMeshAgent == null)
		{
			Debug.LogError("The nav mesh agent component is not attached to " + gameObject.name);
		}	
		else
		{
			SetDestination();
		}
	}
	
	private void SetDestination() {
		if(_towerLocation != null)
		{
			Vector3 targetVector = _towerLocation.transform.position;
			_navMeshAgent.SetDestination(targetVector);
		}
	}
}
