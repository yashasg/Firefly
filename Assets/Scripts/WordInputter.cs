using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WordInputter : MonoBehaviour {

    public InputField inputField;
    public Text displayText;
    int wordsEntered = 0;
    int maxWords = 5;
    int minWordLength = 3;
    string guiControlName = "TextEntry";
    public string[] traumaticWords;
    
    enum EntryError {
        Valid=0,
        Short =1
    }

    void Awake(){
        inputField.onEndEdit.AddListener(SubmitName);
        traumaticWords = new string[maxWords];
        
    }

    void SubmitName(string tWord){
        switch (GetEntryValidity(tWord)){
            case EntryError.Valid:
                traumaticWords[wordsEntered] = tWord;
                displayText.text += tWord + "\n";
                inputField.text = "";
                GUI.FocusControl(guiControlName);
                wordsEntered++;
                if (wordsEntered == maxWords){
                    Debug.Log("Five Words Entered!");
                    inputField.enabled = false;
                    //MoveToGameScene();
                }
                break;
            case EntryError.Short:
                Debug.Log("SHORT!");
                //Display Short Error Message
                break;
        }
    }

    void MoveToGameScene() {
        GameManager.Instance.StoreTraumaticWords(traumaticWords);
        //Do some gradual animation
        SceneManager.LoadScene((int)SceneNames.Game);
    }

    EntryError GetEntryValidity(string textInput) {
        if (textInput.Length < minWordLength) {
            return EntryError.Short;
        }
        return EntryError.Valid;
    }
}
