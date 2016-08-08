using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WordInputter : MonoBehaviour {

    public GameObject ErrorMsg;
    public Text errorMsgTxt;
    public InputField inputField;
    public Text displayText;
    int wordsEntered = 0;
    int maxWords = 5;
    int minWordLength = 3;
    string guiControlName = "TextEntry";
    public string[] traumaticWords;
    string validString = "abcdefghijklmnopqrstuvwxyz";
    char[] validCharacters;

    enum EntryError {
        Valid=0,
        Short =1,
        CharNotSupported=2,
        Empty =3
    }

    void Awake(){
        inputField.onEndEdit.AddListener(SubmitName);
        inputField.onValueChanged.AddListener(BeginTyping);
        inputField.ActivateInputField();
        inputField.Select();
        validCharacters = validString.ToCharArray();
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
                errorMsgTxt.text = "Please enter a word >3 characters";
                //Display Short Error Message
                break;
            case EntryError.CharNotSupported:
                Debug.Log("bad char!");
                ErrorMsg.SetActive(true);
                errorMsgTxt.text = "Please enter only letters (no spaces, special characters)";
                break;
            case EntryError.Empty:
                break;

        }
    }

    void MoveToGameScene() {
        GameManager.Instance.ToggleTextCanvas(false);
        JarManager.Instance.StoreWords(traumaticWords);

    }

    EntryError GetEntryValidity(string textInput) {
        textInput = textInput.ToLower();
        if (textInput.Length < minWordLength) {
            return EntryError.Short;
        }
        if (textInput == "") {
            return EntryError.Empty;
        }
        foreach (char letter in textInput) {
            bool isValid = false;
            foreach (char myLetter in validCharacters) {
                if (myLetter == letter) {
                    isValid = true;
                    break;
                }
            }
            if (!isValid) {
                return EntryError.CharNotSupported;
            }
        }
        return EntryError.Valid;
    }

    
}
