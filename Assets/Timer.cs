using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    float m_timer;
    float gameTimer;
	// Use this for initialization
	void Start () {
        m_timer = PlayerPrefs.GetFloat("Timer");
        gameTimer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (m_timer >= gameTimer)
        {
            SceneManager.LoadScene(0);
        }
	
	}
}
