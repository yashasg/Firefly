using UnityEngine;
using System.Collections;

public class JarManager : MonoBehaviour {

    public static JarManager Instance;
    public GameObject jar, jarAddEffect;
    public Transform[] jarSpots;
    public bool up;

    int targetJar;
    int jarCount;
    int fireflyCount=0;

	void Start () {
        Instance = this;
    }

    void Update() {
        if (up) {
            up = false;
            AddFireFly();
        }
    }

    //The WordInput Calls this when the word is entered
    public void SetJarCount(int lettersInWord) {
        jarCount = lettersInWord;
    }

    //The Hover Sensor calls this when looking to transport to the targetJar
    public Vector3 GetTargetJarPosition() {
        return jarSpots[targetJar].position;
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
        if (targetJar == jarCount) {
            targetJar = 0;
        }
    }
	
}
