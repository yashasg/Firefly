using UnityEngine;
using System.Collections;

[RequireComponent (typeof(NavMeshAgent))]
public class Movement : MonoBehaviour {

    public static Movement Instance;
	private NavMeshAgent navAgent;
	public Transform[] transforms;
	private int navIndex = 0;
    

	public GameObject NavPoints;
	public float navDistanceOffset = 0.005f;

	void Start () {
        Instance = this;
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
		if (!navAgent.pathPending)
		{
			if (navAgent.remainingDistance <= navAgent.stoppingDistance)
			{
				if (!navAgent.hasPath || navAgent.velocity.sqrMagnitude == 0f)
				{
					// Done
					GoToNextNavPoint();
				}
			}
		}
	}

	void GoToNextNavPoint() {
		// No Nav Points
		if (transforms.Length == 0 ) return;
		navIndex = (navIndex) % (transforms.Length - 1) + 1;
		navAgent.destination = transforms[ navIndex ].transform.position;
	}
}
