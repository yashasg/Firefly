using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class JarManager : MonoBehaviour {

    public static JarManager Instance;
    public GameObject jarParent;
    public GameObject lettersParent;
    GameObject[] jars;
    GameObject[] letters;
    Text[] letterTexts;
    public bool up, resetJars;

    string[] traumaticWords;
    int targetJar;
    int currentWordLength;
    int fireflyCount=0;

    public float jarSpacing = 1.35f;

	void Start () {
        Instance = this;
        jars = new GameObject[jarParent.transform.childCount];
        letters = new GameObject[lettersParent.transform.childCount];
        letterTexts = new Text[lettersParent.transform.childCount];
        SetJars();
        SetLetters();
    }

    void SetJars() {
        int i = 0;
        foreach (Transform child in jarParent.transform)
        {
            jars[i] = child.gameObject;
            i++;
        }
        
        ResetJars();
    }

    void SetLetters() {
        int i = 0;
        foreach (Transform child in lettersParent.transform)
        {
            letters[i] = child.gameObject;
            letterTexts[i] = letters[i].GetComponent<Text>();
            i++;
        }
        ResetLetters();
    }

    void ResetLetters() {
        Vector3 startLetterSpot = jars[0].transform.position;
        Debug.Log(startLetterSpot);
        for (int j = 0; j < jars.Length; j++){
            Vector3 newOffset = Vector3.right * jarSpacing * j + Vector3.up * -0.4f;
            letters[j].transform.position = startLetterSpot + newOffset;
        }
    }

    void ResetJars() {
        Vector3 startJarSpot = jars[0].transform.position;
        for (int j = 0; j < jars.Length; j++){
            Vector3 newOffset = Vector3.right * jarSpacing * j;
            jars[j].transform.position = startJarSpot + newOffset;
        }
    }

    void Update() {
        if (up) {
            up = false;
            AddFireFly();
        }
        if (resetJars) {
            resetJars = false;
            ResetJars();
            ResetLetters();
        }
    }

    //The WordInput Calls this when the word is entered
    public void StoreWords(string[] traumaticWords) {
        this.traumaticWords = traumaticWords;
        LoadJars(traumaticWords[0]);
    }

    void LoadJars(string currentWord) {
        currentWordLength = currentWord.Length;
        for (int i = 0; i < jars.Length; i++) {
            bool jarPresent = i < currentWordLength ? true : false;
            jars[i].SetActive(jarPresent);
            letters[i].SetActive(jarPresent);

            if (jarPresent) {
                letterTexts[i].text = currentWord[i].ToString();
            }
        }
    }

    //The Hover Sensor calls this when looking to transport to the targetJar
    public Vector3 GetTargetJarPosition() {
        return jars[targetJar].transform.position;
    }

    //The HoverSensor calls this when onMouseOver() destroys it
    public void AddFireFly() {
        fireflyCount++;
        //Instantiate new Firefly? save that for another manager

        //Every 5th firefly, start adding to a new jar
        if (fireflyCount % 5 == 0) {
            SwitchTargetJar();
        }
    }

    void SwitchTargetJar() {
        targetJar++;
        if (targetJar == currentWordLength) {
            targetJar = 0;
        }
    }
	
}
