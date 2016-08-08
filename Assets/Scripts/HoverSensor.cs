using UnityEngine;
using System.Collections;

public class HoverSensor : MonoBehaviour {
    float m_timercatcher;
    public float m_hovertime;
    public AudioSource m_sound;

	// Use this for initialization
	void Start () {
        m_sound = GetComponent<AudioSource>();

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
            AudioSource.PlayClipAtPoint(m_sound.clip, Camera.main.gameObject.transform.position);
            //m_sound.PlayOneShot();
           // JarManager.Instance.AddFireFly();
           // sendToJar();
           
           Destroy(gameObject);
        }
        else
            m_timercatcher += Time.deltaTime;
    }

    void sendToJar()
    {
       Vector3 dest = JarManager.Instance.GetTargetJarPosition();
        gameObject.transform.position.Set(dest.x,dest.y,dest.z);

    }
}
