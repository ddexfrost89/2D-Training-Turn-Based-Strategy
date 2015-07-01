using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {


	private int childnumber = 0;
	private GameObject activechild = null;
	public GameObject targetchild = null;
	public bool IsEntering = false;
	public bool IsMenu = false;
	public string EntS = ""; // Entering String

	// Use this for initialization
	void Start () {
	
	}

	void AddChild(){
	}

	void ShowMenu(){
	}

	void SolveEntS(){
	}

	string LetterEnt (){
		if (IsEntering) {
			return Input.inputString;
		}
		return "";
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Mouse0)){
			if (targetchild != null) {
				if(activechild == null){
					activechild = targetchild;
				}
				else if(targetchild != activechild){
					activechild = null;
				}
				targetchild = null;
			}
			else {
				if(activechild != null){
					activechild.GetComponent<UserControl>().Move();
					activechild = null;
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.KeypadEnter) || Input.GetKeyDown (KeyCode.Return)) {
			if(IsEntering){
				SolveEntS();
				EntS = "";
			}
			IsEntering = !IsEntering;

		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if(IsEntering){
				IsEntering = false;
				EntS = "";
			}
			else{
				IsMenu = !IsMenu;
				if(IsMenu)
					ShowMenu();
			}
		}
		if (IsEntering) {
			if (Input.GetKeyDown (KeyCode.Backspace) && EntS.Length > 0) {
				EntS = EntS.Remove (EntS.Length - 1);
			} else 
				EntS = EntS + LetterEnt ();
		}
	}
}
