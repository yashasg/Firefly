using UnityEngine;
using System.Collections;

public enum SceneNames
{
    Title=0,
    Game=1
}

public class GameManager : MonoBehaviour {

    public static GameManager Instance;
    public GameObject TextCanvas;


    void Awake() {
        Instance = this;
    }

    public void ToggleTextCanvas(bool turnOn) {
        TextCanvas.SetActive(turnOn);
        if (turnOn){
            StartCoroutine(GoToGame());
        }
        else {

        }
    }

    IEnumerator GoToGame() {
        yield return null;
    }
}
