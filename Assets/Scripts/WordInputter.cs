using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WordInputter : MonoBehaviour {

    public GameObject ErrorMsg;
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

    void Start(){
        inputField.onEndEdit.AddListener(SubmitName);
        inputField.onValueChanged.AddListener(BeginTyping);
        inputField.ActivateInputField();
        inputField.Select();
        traumaticWords = new string[maxWords];
        
    }

    void BeginTyping(string input) {
        ErrorMsg.SetActive(false);
    }

    void SubmitName(string tWord){
        inputField.ActivateInputField();
        inputField.Select();

        switch (GetEntryValidity(tWord)){
            case EntryError.Valid:
                traumaticWords[wordsEntered] = tWord;
                displayText.text += tWord + "\n";
                
                inputField.text = "";
                wordsEntered++;
                if (wordsEntered == maxWords){
                    inputField.enabled = false;
                    MoveToGameScene();
                }
                break;
            case EntryError.Short:
                Debug.Log("SHORT!");
                ErrorMsg.SetActive(true);
                //Display Short Error Message
                break;
        }
    }

    void MoveToGameScene() {
        GameManager.Instance.ToggleTextCanvas(false);
        JarManager.Instance.StoreWords(traumaticWords);

    }

    EntryError GetEntryValidity(string textInput) {
        if (textInput.Length < minWordLength) {
            return EntryError.Short;
        }
        return EntryError.Valid;
    }
}
