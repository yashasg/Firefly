using UnityEngine;
using System.Collections;

public class HoverSensor : MonoBehaviour {
    float m_timercatcher;
    public float m_hovertime;
    AudioSource m_sound;
    public GameObject my_Firefly;
    public GameObject ParticleEffect;
    bool isInvoked = false;

	// Use this for initialization
	void Start () {
        m_sound = GetComponent<AudioSource>();
        ParticleEffect.SetActive(true);


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
            //AudioSource.PlayClipAtPoint(m_sound.clip, Camera.main.gameObject.transform.position);
            //m_sound.PlayOneShot();
           sendToJar();
          //  Invoke("makeNewFly", 1.0f);
           // Destroy(GetComponent<Movement>());
        }
        else
            m_timercatcher += Time.deltaTime;
    }
    void makeNewFly()
    {
        Instantiate(my_Firefly);
     
    }

    void sendToJar()
    {
        JarManager.Instance.AddFireFly();
        Vector3 dest = JarManager.Instance.GetTargetJarPosition();
        gameObject.transform.position.Set(dest.x,dest.y,dest.z);

    }
}
