using UnityEngine;
using System.Collections;

[RequireComponent (typeof(NavMeshAgent))]
public class Movement : MonoBehaviour {

	private NavMeshAgent navAgent;
	private Transform[] transforms;
	private int navIndex = 0;

	public GameObject NavPoints;
	public float navDistanceOffset = 0.5f;

	void Start () {
		
		navIndex = 0;
		navAgent = GetComponent<NavMeshAgent>();
		navAgent.updateRotation = false;

		if ( NavPoints != null ) {
			transforms = NavPoints.GetComponentsInChildren<Transform>();
		}
		else {
			Debug.Log("Add Nav Points to move the character");
		}

	}
	
	// Update is called once per frame
	void Update () {
		if ( navAgent.remainingDistance < navDistanceOffset ) {
			GoToNextNavPoint();
		}
	}

	void GoToNextNavPoint() {
		// No Nav Points
		if (transforms.Length == 0 ) return;

		navAgent.destination = transforms[ navIndex ].transform.position;

		navIndex = (navIndex + 1) % transforms.Length; 
	}
}
