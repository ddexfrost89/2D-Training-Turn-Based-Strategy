using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {


	public int unitnumber = 0;
	private int buildingnumber = 0;
	private int workernumber = 0;
	public GameObject activechild = null;
	public GameObject targetchild = null;
	private bool IsEntering = false;
	private bool IsMenu = false;
	private string EntS = ""; // Entering String
	private GameObject UnitSample;
	private GameObject BuildingSample;
	private GameObject WorkerSample;
	private const int MaxUnits = 999;

	// Use this for initialization
	void Start () {
		UnitSample = transform.Find ("Unit_1000").gameObject;
	}

	void AddUnit(Vector3 CreationPos){
		if (unitnumber < MaxUnits) {
			GameObject newunit = (GameObject)Instantiate (UnitSample,
		                                              	  CreationPos,
		                                              		transform.rotation);
			newunit.name = "unit_" + unitnumber.ToString();
			newunit.transform.parent = gameObject.transform;
			newunit.transform.localScale = newunit.transform.lossyScale;
			unitnumber++;
		}
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
		if (Input.GetKeyDown (KeyCode.LeftControl)) {
			AddUnit(new Vector3 (4, 4, -1));
		}
	}
}
