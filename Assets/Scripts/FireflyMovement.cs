using UnityEngine;
using System.Collections;

public class FireflyMovement : MonoBehaviour {
    public GameObject m_Firefly;
    public float m_speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        m_Firefly.transform.Translate(Vector2.right*Time.deltaTime*m_speed);
	}
}
