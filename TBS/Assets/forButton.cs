using UnityEngine;
using System.Collections;

public class forButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void ButtonFunction() {  //код для кнопки сюда
	}

	void OnGUI() {
		if (GUI.Button (new Rect (0, Screen.height - 30, 75, 20), "Press me")) {
			ButtonFunction();
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
