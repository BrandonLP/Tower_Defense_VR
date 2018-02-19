using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {
	//Movement of AI created using tutorial from AI and Games Channel on Youtube
	//"Nav Mesh Basics: Unity Pathfinding Part 1"
	//https://www.youtube.com/watch?v=rKGq42FMV8c
	//basic mechanics also observed through Mountain God VR code

	[SerializeField]
	public Transform _targetLocation;

	[Tooltip("Amount enemy speed is multipled by")]
	public float _enemySpeed = 1.0f;

	NavMeshAgent _navMeshAgent;

	// Use this for initialization
	private void Start () {
		_navMeshAgent = this.GetComponent<NavMeshAgent> ();
		_navMeshAgent.speed *= _enemySpeed;
		if(_navMeshAgent == null)
		{
			Debug.LogError("The nav mesh agent component is not attached to " + gameObject.name);
		}	
		else
		{
			SetDestination();
		}
	}

	/*multiplies the current speed and other speed things by the newSpeedMultipler*/
	/*public void SetSpeed(float newSpeedMultiplier) {
		_navMeshAgent.speed *= newSpeedMultiplier;
		_navMeshAgent.angularSpeed *= newSpeedMultiplier;
		_navMeshAgent.acceleration *= newSpeedMultiplier;
	}*/

	/*if a target location is set, then the navmeshagent will go to that vector3*/
	private void SetDestination() {
		if(_targetLocation != null)
		{
			Vector3 targetVector = _targetLocation.transform.position;
			_navMeshAgent.SetDestination(targetVector);
		}
	}
}
