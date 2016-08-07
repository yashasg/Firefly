using UnityEngine;
using System.Collections;

[RequireComponent (typeof(MeshRenderer))]
public class NavPoint : MonoBehaviour {

	private MeshRenderer m_renderer;

	// Use this for initialization
	void Start () {
		m_renderer = GetComponent<MeshRenderer>();
		m_renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
