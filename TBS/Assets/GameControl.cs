using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {


	private int childnumber = 0;
	private GameObject activechild = null;
	public GameObject targetchild = null;

	// Use this for initialization
	void Start () {
	
	}

	void AddChild(int code){
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
			}
		}
	}
}
