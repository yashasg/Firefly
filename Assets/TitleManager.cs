using UnityEngine;
using System.Collections;

public class TitleManager : MonoBehaviour {

	public void EnablePanel(GameObject panel)
    {
        panel.SetActive(true);
    }
    public void DisablePanel(GameObject panel)
    {
        panel.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void setGameTime(float i_timer)
    {
        PlayerPrefs.SetFloat("Timer", i_timer);
    }

}
