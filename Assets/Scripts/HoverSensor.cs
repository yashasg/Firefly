using UnityEngine;
using System.Collections;

public class HoverSensor : MonoBehaviour {
    float m_timercatcher;
    public float m_hovertime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnMouseOver()
    {
        Debug.Log(m_timercatcher.ToString());
        if (m_timercatcher > m_hovertime)
        {
            m_timercatcher = 0.0f;
            JarManager.Instance.AddFireFly();
            Destroy(gameObject);
        }
        else
            m_timercatcher += Time.deltaTime;
    }
}
