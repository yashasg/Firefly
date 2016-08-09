using UnityEngine;
using System.Collections;

public class HoverSensor : MonoBehaviour {
    float m_timercatcher;
    public float m_hovertime;
    AudioSource m_sound;
    public GameObject my_Firefly;

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
            sendToJar();
            makeNewFly();
           //Destroy(gameObject);
        }
        else
            m_timercatcher += Time.deltaTime;
    }
    void makeNewFly()
    {
        transform.position = Movement.Instance.transforms[Random.Range(0,5)].position;
     
    }

    void sendToJar()
    {
        JarManager.Instance.AddFireFly();
        Vector3 dest = JarManager.Instance.GetTargetJarPosition();
        gameObject.transform.position.Set(dest.x,dest.y,dest.z);

    }
}
