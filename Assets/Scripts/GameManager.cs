using UnityEngine;
using System.Collections;

public enum SceneNames
{
    Title=0,
    Game=1
}

public class GameManager : MonoBehaviour {

    public static GameManager Instance;


    string[] traumaticWords;



    //The Input
    public void StoreTraumaticWords(string[] traumaticWords) {
        this.traumaticWords = traumaticWords;
    }

    public void AnimateSceneTransition(){
        StartCoroutine(GoToGame());
    }
    IEnumerator GoToGame() {
        yield return null;
    }

    public string[] GetTraumaticWords() { return traumaticWords; }
}
